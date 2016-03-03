//Napson EC-80P Data Collection Software
//Author: Russ Renzas, 2014-2015
//Purpose: Records data from Napson EC-80P noncontact resistance probe attached via serial port.
//Napson EC-80P computer connection just spits out fairly opaque data to a serial port with no program to
//save, collect, organize, or otherwise deal with the data. This program handles everything nicely. 
//Tested and used for tens of thousands of measurements in windows 7
//Open source, attribution required for use.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace NapsonExpanded
{
    public partial class MenuForm : Form
    {
        string noReads = "1000000";
        double overReadd = 50000;
        string overReads = "50000";
        Random rand = new Random();
        List<string> receivedData;
        bool currentlyMeasuring;
        SerialPort serialPort;
        string strDOEname;
        int x;
        int y;
        Button[,] buttonArray;
        string[,] dataArray;
        Label[] labelArrayX;
        Label[] labelArrayY;
        OpenFileDialog openFileDialog;
        bool existingFile = false;

        Point currPoint = new Point(0, 0);

        //int portNum;

        public MenuForm()
        {
            InitializeComponent();
            receivedData = new List<string>();
            currentlyMeasuring = false;
            numericUpDown1.Value = NapsonExpanded.Properties.Settings.Default.portSet;
            numericUpDownX.Value = NapsonExpanded.Properties.Settings.Default.r;
            numericUpDownY.Value = NapsonExpanded.Properties.Settings.Default.c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //deprecated, not called now
            if (!currentlyMeasuring) BeginMeasuring();
            else StopMeasuring();
        }

        private bool BeginMeasuring()
        {
            receivedData.Clear();
            serialPort = new SerialPort("COM" + ((int)numericUpDown1.Value).ToString()); 
            try
            {
                serialPort.BaudRate = 19200;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 1000;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.Open();
                buttonNoData.Enabled = true;
                buttonNoData.Focus();
                buttonNewSample.Enabled = true;
                currentlyMeasuring = true;
                return true;
            }
            catch
            {
                MessageBox.Show("Failed. Check connections and port.");
                //StopMeasuring();
                serialPort.Close();
                currentlyMeasuring = false;
                buttonNoData.Enabled = false;
                //buttonNewSample_Click((object)buttonStartDOE, new EventArgs());
                numericUpDownX.Enabled = true;
                numericUpDownY.Enabled = true;
                textBoxDOE.Enabled = true;
                buttonEndDOE.Enabled = false;
                buttonStartDOE.Enabled = true;
                buttonNewSample.Enabled = false;
                buttonNoData.Enabled = false;
                openFileButton.Enabled = true;
                existingFile = false;
            }
            return false;

        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadLine();
            this.Invoke((MethodInvoker)delegate
            {
                string data = ProcessRawData(s);
            });
        }


        private void StopMeasuring()
        {
            serialPort.Close();
            currentlyMeasuring = false;
            buttonNoData.Enabled = false;
            foreach (Button b in buttonArray) b.Visible = false;
            foreach (Label l in labelArrayX) l.Dispose();
            foreach (Label l in labelArrayY) l.Dispose();
        }

        private string ProcessRawData(string str)
        {
            buttonNewSample.Enabled = true;
            string s = str.Split(',')[4];    //splits to comma-delimited, extracts OPS as x.yyye+zz
            string[] halves = s.Split('e');
            double OPS = double.Parse(halves[0]);
            int exp = int.Parse(halves[1]);
            OPS = OPS*Math.Pow(10, exp);
            s = Math.Round(OPS, 3).ToString();
            if (s == "-1") s = overReads;
            labelReading.Text = "Last Reading: " + s + " OPS";
            if (s != overReads) buttonArray[currPoint.X, currPoint.Y].Text = s;    //really weird use of if/else's here, but works so no need to change?
            else buttonArray[currPoint.X, currPoint.Y].Text = overReads;
            if (s == overReads) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Red;
            else if (OPS < 150) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Green;
            else if (OPS > 300) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Orange;
            else buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Yellow;
            dataArray[currPoint.X, currPoint.Y] = s;
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Black;
            if (currPoint.X < x - 1) currPoint.X++;
            else
            {
                currPoint.X = 0;
                if (currPoint.Y < y - 1) currPoint.Y++;
                else currPoint.Y = 0;
            }
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Red;
            if (buttonArray[currPoint.X, currPoint.Y].BackColor == Color.Red) buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Yellow;
            return txtBoxID.Text + "," + s;
        }

        private bool SaveData(object sender, EventArgs e)
        {
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.FileName = "Napson Data";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "Comma-delimited text files (*.csv)|*.csv";
            saveFileDialog.InitialDirectory = NapsonExpanded.Properties.Settings.Default.SaveDirectory;

            try
            {
                if (existingFile)
                {
                    buttonNewSample_Click(sender, e);
                    string path = openFileDialog.FileName;
                    WriteDataToFile(System.IO.File.AppendText(path));
                    existingFile = false;
                    MessageBox.Show("File saved in original location.");
                }
                else
                {
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        buttonNewSample_Click(sender, e); //necessary to avoid error where it doesn't write current line of data
                        System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.OpenFile());
                        WriteDataToFile(file);
                        NapsonExpanded.Properties.Settings.Default.SaveDirectory = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                        NapsonExpanded.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("File not saved.");
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("File open in another program. Close program or use a different file name and try again.");
                return false;
            }
            return true;
        }

        private void WriteDataToFile(System.IO.StreamWriter file)
        {
            try
            {
                if (!existingFile)
                {
                    string hdr = "DOE ID,Sample ID, Avg. OPS, SD OPS, % Uniformity, % No Read,";
                    for (int j = 0; j < y; j++) //swapped in front 7/23/14
                        for (int i = 0; i < x; i++)
                            //for (int j = 0; j < y; j++)
                            //                        hdr += (i + 1).ToString() + "-" + (j + 1).ToString() + " (OPS),"; //old version changed 7/22/14
                            hdr += (j + 1).ToString() + "-" + (i + 1).ToString() + " (OPS),";
                    file.WriteLine(hdr);
                }
                foreach (string s in receivedData)
                {
                    file.WriteLine(s);
                }
                file.Close();
            }
            catch { MessageBox.Show("Error. Check file name and data integrity."); return; }
        }

        private void buttonNoData_Click(object sender, EventArgs e)
        {
            buttonNewSample.Enabled = true;
            string s = noReads;
            labelReading.Text = "Last Reading: " + s + " OPS";
            buttonArray[currPoint.X, currPoint.Y].Text = s;
            buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Red;
            dataArray[currPoint.X, currPoint.Y] = s;
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Black;
            if (currPoint.X < x - 1) currPoint.X++;
            else
            {
                currPoint.X = 0;
                if (currPoint.Y < y - 1) currPoint.Y++;
                else currPoint.Y = 0;
            }
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Red;
            if (buttonArray[currPoint.X, currPoint.Y].BackColor == Color.Red) buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Yellow;
        }

        private void buttonStartDOE_Click(object sender, EventArgs e)
        {
            if(!BeginMeasuring()) return;
            currPoint.X = 0;
            currPoint.Y = 0;
            strDOEname = textBoxDOE.Text;
            x = (int)numericUpDownX.Value;
            y = (int)numericUpDownY.Value;
            buttonStartDOE.Enabled = false;
            numericUpDownX.Enabled = false;
            numericUpDownY.Enabled = false;
            textBoxDOE.Enabled = false;

            buttonEndDOE.Enabled = true;
            buttonNewSample.Enabled = false;
            openFileButton.Enabled = false;

            
            buttonArray = new Button[x,y];
            dataArray = new string[x, y];
            labelArrayX = new Label[x];
            labelArrayY = new Label[y];
            receivedData.Clear();    

            NapsonExpanded.Properties.Settings.Default.r = x;
            NapsonExpanded.Properties.Settings.Default.c = y;
            NapsonExpanded.Properties.Settings.Default.Save();

            int width = groupBoxMeasurements.Size.Width-40;
            int height = groupBoxMeasurements.Size.Height-50;

            

            for(int i = 0; i<x;i++)
                for (int j = 0; j < y; j++)
                {
                    dataArray[i, j] = noReads;
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Location = new Point(width / x * i+25, height/y*j+35);
                    buttonArray[i, j].Width = width / x;
                    buttonArray[i, j].Height = height / y;
                    buttonArray[i, j].Text = "(" + (j+1).ToString() + "," + (i+1).ToString() + ")"; //swapped i & j, 5/22/14
                    buttonArray[i, j].Tag = new Point(i, j);
                    buttonArray[i, j].FlatStyle = FlatStyle.Popup;
                    buttonArray[i, j].Click += new EventHandler(ButtonClick);
                    if (x < 10 && y < 10) buttonArray[i, j].Font = new Font(buttonArray[i, j].Font.FontFamily, 15);
                    groupBoxMeasurements.Controls.Add(buttonArray[i, j]);
                }
            buttonArray[0, 0].ForeColor = Color.Red;
            for (int i = 0; i < x; i++)
            {
                labelArrayX[i] = new Label();
                labelArrayX[i].AutoSize = true;
                labelArrayX[i].Text = (i + 1).ToString();
                labelArrayX[i].Location = new Point((width * i / x) + (width / x)/2+25, 15);
                groupBoxMeasurements.Controls.Add(labelArrayX[i]);
            }
            for (int i = 0; i < y; i++)
            {
                labelArrayY[i] = new Label();
                labelArrayY[i].AutoSize = true;
                labelArrayY[i].Text = (i + 1).ToString();
                labelArrayY[i].Location = new Point(5, (height * i / y) + (height / y)/2+25);
                groupBoxMeasurements.Controls.Add(labelArrayY[i]);
            }

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point p = (Point)btn.Tag;
            currPoint.X = p.X;
            currPoint.Y = p.Y;
            foreach (Button b in buttonArray) b.ForeColor = Color.Black;
            btn.ForeColor = Color.Red;
            if (btn.BackColor == Color.Red) btn.ForeColor = Color.Yellow;
        }

        private void buttonNewSample_Click(object sender, EventArgs e)
        {
            string dataLine = textBoxDOE.Text + "," + txtBoxID.Text + ",";
            double avg = 0;
            double SD = 0;
            double pBad;
            double pUniformity;
            int bad = 0;
            //calc avg.
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    double val = double.Parse(dataArray[i, j]);
                    avg += val;
                    if (val > overReadd +1.0) bad++;
                }
//            avg = avg / (double)((x * y) - bad);
            avg = avg / (double)((x * y)); //7/23/14 now counts bad points normally
            //calc standard dev.
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    double val = double.Parse(dataArray[i, j]);
                    SD += Math.Pow((val - avg), 2);
                }
//            SD = Math.Sqrt(SD / ((double)(x * y) - bad));
            SD = Math.Sqrt(SD / ((double)(x * y))); //7/23/14 now counts bad points normally
            //% uniformity
            pUniformity = SD/avg * 100;

            //% Bad
            pBad = (double)bad / ((double)x * (double)y) * 100;
            //add data
            dataLine += avg.ToString() + "," + SD.ToString() + "," + pUniformity.ToString() + "," + pBad.ToString() + ",";
            for (int j = 0; j < y; j++)
                for (int i = 0; i < x; i++) //5/22/14 swapped order of for loops
                    if (double.Parse(dataArray[i, j]) > overReadd - 1.0 && double.Parse(dataArray[i,j]) < overReadd +1.0) dataLine += overReads + ",";//">1300,"; - 1300 = max of Napson //140610 added +","
                    else dataLine += dataArray[i, j] + ",";
            
            receivedData.Add(dataLine);

            txtBoxID.Text = "";
            currPoint.X = 0;
            currPoint.Y = 0;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    dataArray[i, j] = noReads;
                    buttonArray[i, j].Text = "(" + i.ToString() + "," + j.ToString() + ")";
                    buttonArray[i, j].ForeColor = Color.Black;
                    buttonArray[i, j].BackColor = buttonEndDOE.BackColor;
                }
            buttonArray[0, 0].ForeColor = Color.Red;
            buttonNewSample.Enabled = false;
        }

        private void buttonEndDOE_Click(object sender, EventArgs e)
        {
            StopMeasuring();
            if (SaveData(sender, e))
            {
                
                numericUpDownX.Enabled = true;
                numericUpDownY.Enabled = true;
                textBoxDOE.Enabled = true;
                buttonEndDOE.Enabled = false;
                buttonStartDOE.Enabled = true;
                buttonNewSample.Enabled = false;
                buttonNoData.Enabled = false;
                openFileButton.Enabled = true;
                //StopMeasuring();
            }
            
        }

        private void portChange(object sender, EventArgs e)
        {
            NapsonExpanded.Properties.Settings.Default.portSet = numericUpDown1.Value;
            NapsonExpanded.Properties.Settings.Default.Save();
        }

        private void buttonFake_Click(object sender, EventArgs e)
        {
            int OPS = rand.Next(1500);
            int colorScore = (OPS - 50) / 2;
            string s = OPS.ToString();
            labelReading.Text = "Last Reading: " + s + " OPS";
            buttonArray[currPoint.X, currPoint.Y].Text = s;
            if (s == noReads || colorScore > 512) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Red;
            else if (colorScore < 0) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.Green;
            else if (colorScore > 255) buttonArray[currPoint.X, currPoint.Y].BackColor = Color.FromArgb(255, colorScore - 255, 0);
            else buttonArray[currPoint.X, currPoint.Y].BackColor = Color.FromArgb(colorScore, 255, 0);
            dataArray[currPoint.X, currPoint.Y] = s;
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Black;
            if (currPoint.X < x - 1) currPoint.X++;
            else
            {
                currPoint.X = 0;
                if (currPoint.Y < y - 1) currPoint.Y++;
                else currPoint.Y = 0;
            }
            buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Red;
            if (buttonArray[currPoint.X, currPoint.Y].BackColor == Color.Red) buttonArray[currPoint.X, currPoint.Y].ForeColor = Color.Yellow;
            currentlyMeasuring = true;
            buttonNoData.Enabled = true;
            buttonNoData.Focus();
            buttonNewSample.Enabled = true;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".csv Files (.csv)|*.csv";
            openFileDialog.Multiselect = false;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                existingFile = true;
                buttonStartDOE_Click(sender, e);
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentlyMeasuring)
            {
                buttonEndDOE_Click(sender, e);
            }
        }
    }
}
