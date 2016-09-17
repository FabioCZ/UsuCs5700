CS5700 HW 1
Fabio Gottlicher
A01647928


To run matcher with provided data:
1. Build from Visual Studio
2. Choose a way to run:
	- execute RunWithSampleData.bat from root of the project
	- Run from Visual Studio (with the provided .csproj.user config present)
	- run executable with the following arguments:
		--input TestData/PersonTestSet_01.json,Json%3bTestData/PersonTestSet_02.json,Json%3bTestData/PersonTestSet_03.json,Json%3bTestData/PersonTestSet_04.json,Json%3bTestData/PersonTestSet_05.json,Json%3bTestData/PersonTestSet_11.xml,Xml%3bTestData/PersonTestSet_12.xml,Xml%3bTestData/PersonTestSet_13.xml,Xml%3bTestData/PersonTestSet_14.xml,Xml%3bTestData/PersonTestSet_15.xml,Xml --output MatcherOutput.txt

To run unit tests:
Use Visual Studio's Unit test runner and run all tests


UML:
UML diagrams are in the UML folder




---------------------------

>Cs5700Hw1.exe --help
Cs5700Hw1 1.0.0.0
Copyright c  2016

  -i, --input     Required. The names and types of the file inputs, e.g. -i
                  file1.json,Json;file2.xml,Xml, format is
                  <file_name>,<file_type>;<file_name>,<file_type>; ... etc.
                  Valid file types are 'Xml' and 'Json'

  -o, --output    (Default: out.txt) The name of the output result file.
                  default=out.txt

  --help          Display this help screen.