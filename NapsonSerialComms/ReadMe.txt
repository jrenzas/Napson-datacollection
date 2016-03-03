Project: Napson Data Acquisition v3
Purpose: Improved data collection and mapping from Napson EC-80P.
Author: Russ Renzas
Date: March 2015

Language: C#
IDE Used: Visual Studio Express 2012

Open sourced WITH PERMISSION, because original company it was used at closed (much to my dismay).

Resolved Bugs:
	- Fixed average and SD when they incorporate bad points
	- Fixed headers
	- Fixed row/column swapping in data output
	- Now saves over-range data as 50000.
	- Now saves no-read as 1000000.
	- Now includes over-range and no-read in average.
	- % Bad changed to % No Read, includes just the no-reads.
	- fixed 50000 concatenation bug
	- Canceling save/close DOE no longer deletes all data
	- Added save option when closing
	- Added open file option to add to old files

Unresolved Bugs:
	- Improve OPS color-coding (tried version of this, but it just looks weird, not useful)
