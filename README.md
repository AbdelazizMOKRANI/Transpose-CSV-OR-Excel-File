# Transpose-CSV-OR-Excel-File 
This repository will show you how to a Read CSV or Excel file and converted to transposed table

Concept of the script: The table will be read from an csv file (separated via “;”) and a new file will be created containing the transposed (rotated) table

-	The tool shall be able to receive the filename of the table from the user and load the table to transpose the content. 
-	The tool shall be able to save the transposed table in a new file with the filename of the input file and extended with “transposed” (“filename_transposed.csv”).

* Example 
Input Data 

a1,b1,c1,d1,e1
a2,b2,c2,d2,e2
a3,b3,c3,d3,e3
a4,b4,c4,d4,e4
a5,b5,c5,d5,e5
a6,b6
a7,b7,c7,d7
a8,b8,c8

Output

a1,a2,a3,a4,a5,a6,a7,a8
b1,b2,b3,b4,b5,b6,b7,b8
c1,c2,c3,c4,c5,,c7,c8
d1,d2,d3,d4,d5,,d7,
e1,e2,e3,e4,e5,,
