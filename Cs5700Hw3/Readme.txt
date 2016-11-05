CS5700 Fa2016
HW3
Fabio Gottlicher


-------------------------------------
About
-------------------------------------

This program is implemented using Windows Forms and tested on a Windows 10 machine


-------------------------------------
Cloud database
-------------------------------------

For the cloud database portion, I used Firebase by Google. I used a library to talk to firebase: https://www.nuget.org/packages/FirebaseDatabase.net/2.0.0-alpha7 . This happens in the Firebase Dbo class.


-------------------------------------
Patterns usage
-------------------------------------
Singleton - FirebaseDbo
Factory - CommandFactory, DrawableFactory
Flyweight - SimpleDrawable
Command and Undo - ICommand