CS 5700 HW 2
Fabio Gottlicher, A01647928

This project is made with UWP (Universal Windows Platform). You will need Windows 10 (and quite possibly the anniversary update, build 1607), Visual Studio 2015 with the UWP SDK installed (mine was v.14.0.25527.01). I also included a packaged build of the project in the AppPackages directory. There is a Powershell script in the directory that will install the application.  I didn't include the bin/obj directories, since they were super large.

I wasn't sure if to automatically load the CompanyList.csv or if to let the user pick one. So when launched, the program asks to locate the csv list. I included a copy in the root of the solution.

The Graph views aren't ideal, but it's the only library that I could get to work. Dr. Clyde mentioned that he doesn't want updates in 1 minute intervals, so instead my graph updates every time there is a new message and they keep the latest 60 entries.


You can save the portfolio, and the portfolio information serializes to xml.

UML diagrams are included in the UML folder, included are Visio source files and PDF versions of those.

-----------
OO Patterns
-----------
Observer pattern:
-click listeners for all UI buttons
-Message being received (subject) triggers an event with a listener at each panel (observer)
-Removing a panel (panel is the subject, mainpage is the observer)

Decorator pattern:
-Company can be a simple company, or it can be decorated with a list of messages or a boolean indicating whether it's selected from a list


----------------
Cloud Deployment
----------------
I deployed the simulator on an AWS EC2 server with Windows Server. The server IP is 52.89.90.0 and the exchange simulator is listening on port 12099. I included screenshot of my instance running in the CloudDeployFolder.