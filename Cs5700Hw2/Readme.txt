CS 5700 HW 2
Fabio Gottlicher, A01647928

This project is made with UWP (Universal Windows Platform). You will need Windows 10 (and quite possibly the anniversary update, build 1607), Visual Studio 2015 with the UWP SDK installed (mine was v.14.0.25527.01).

I wasn't sure if to automatically load the CompanyList.csv or if to let the user pick one. So when launched, the program asks to locate the csv list. I included a copy in the root of the solution.

The Graph views aren't ideal, but it's the only library that I could get to work. Dr. Clyde mentioned that he doesn't want updates in 1 minute intervals, so instead my graph updates every time there is a new message and they keep the latest 60 entries.


You can save the portfolio, and the portfolio information serializes to xml.

UML diagrams are included in the UML folder, included are Visio source files and PDF versions of those.
