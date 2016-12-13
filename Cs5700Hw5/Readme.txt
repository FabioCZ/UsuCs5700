CS5700 Fa2016
HW5
Fabio Gottlicher


-------------------------------------
About
-------------------------------------

This program is implemented using Windows Forms and tested on a Windows 10 machine


-------------------------------------
Cloud database
-------------------------------------

For the cloud database portion, I used Firebase by Google. I used a library to talk to 
firebase: https://www.nuget.org/packages/FirebaseDatabase.net/2.0.0-alpha7 . This happens
 in the Firebase Dbo class.


-------------------------------------
Patterns usage
-------------------------------------
Singleton - FirebaseDbo
Factory - CommandFactory, DrawableFactory
Flyweight - SimpleDrawable
Command and Undo - ICommand
State Pattern - selected tool




-------------------------------------
HW5 Improvements Writeup
-------------------------------------

I have implemented a number of improvements on my cat drawing program, which have made it into what I
think is a more solid software system. Many of the improvements came from what was suggested in the 
review meeting, and there are several others that I discovered as I was going through my code.

Improvements from review meeting:
* The invoker and receiver for the command pattern are now 2 separate classes, instead of being in class.
This really makes a lot more sense and I should have done this from the beginning. Before, I had bunch
of [JsonIgnore] attributes for the serializer - this was to tell it not to serialize the fields that had
to do with the invoker side of things. This really broke good encapsulation practices. 
* The New/Open/Save Commands now do not have any WinForms UI code in them. Before, I called my dialogs
straight from those classes. This made it obviously less testable, and is against most UI framework principles.
This also made testing easier - although only for the "New" command. The Open/Save command rely on the database
connection, which is something I did not want to test. Next logical step would be to use a mock framework
to create a mock database object, and use it to test those commands. Unfortunately I am not very familiar
with mocking frameworks in C#, and ran out of time to do this.
* I added more unit test to try out some invalid/error states

Improvements based on the design patterns learned later in the semester:
* I added the state pattern to manage what happens when the drawing board is clicked, depending on what
tool is selected. This base state is an abstract class, with the following extending it: NoToolState,
SelectToolState,AddDrawableState,LineToolState - for each of the tools available. This makes it a lot easier
to handle clicks for the drawing board - a sequence of many if/elses was eliminated.

New Feature:
* I added a new feature - a line drawing tool. This was largely motivated by me using the command pattern as 
well as the state pattern - I wanted to prove (to myself), how these 2 make addition of new features easy.
And it is true...all of it. I was pleasantly surprised that adding a new feature fit very well into the existing
patterns. I was able to implement the line feature without having to modify the existing code to handle new use
cases. 
* To use the line feature, select the line tool. Then click once to define the starting point and again to define
the ending point. A line will be drawn. The width/color of a line are not adjustable.
* The lines are non-selectable/non-removable. To accomplish, the next step would be to make pictures and lines 
inherit a same interface for handling drawable objects.

Overall, this was a great exercise of what it feels like to pick up an existing codebase (one that I thought
I was done with), and add new features to it. I am happy to say that by using OO patterns that we learned,
this experience was not miserable.


-------------------------------------
HW5 Notes
-------------------------------------
* I did not finish my state diagram in time :(
* The solution name is still Cs5700Hw3, I did not rename it for the new homework