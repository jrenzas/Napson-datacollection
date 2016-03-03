Project: Napson Data Acquisition v2.51
Purpose: Improved data collection and mapping from Napson.
Author: Russ Renzas
Date: March 2015

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