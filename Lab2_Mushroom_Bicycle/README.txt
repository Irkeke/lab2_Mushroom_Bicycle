Lab 2 - Bicycle Renting and Mushroom Finder
===========================================

A C# Windows Forms application (.NET Framework 4.8, Windows only).

Files
-----
Program.cs       Entry point; ends the program when the last form closes.
Ui.cs            Shared look (fonts, colours, buttons) and form navigation.
LoginForm.cs     Login: username and password must not be empty.
ChooseForm.cs    Choose Bicycle Renting or Mushroom Finder (or Logout).
BicycleForm.cs   Rental cost calculator with a read-only Total box.
MushroomForm.cs  Yes/no question flow that identifies a mushroom.

Run it with NO downloads (Windows 10 / 11)
------------------------------------------
1. Extract the ZIP file (right-click > Extract All). Do not run from inside the zip.
2. Double-click build.bat. It compiles with the C# compiler built into Windows
   and starts the program. Afterwards you can double-click
   Lab2_Mushroom_Bicycle.exe directly.

Alternative: Visual Studio 2022
-------------------------------
Open Lab2_Mushroom_Bicycle.sln and press F5. The project targets .NET Framework 4.8
(already part of Windows), so the ".NET desktop development" workload is enough.

Validation
----------
Login     Username and password cannot be empty (no other checks).
Bicycle   Start and end must be whole numbers; start 0-23, end 1-24, start < end.
          Invalid input shows a message box and nothing is calculated.
Mushroom  Answers accepted: yes, y, no, n (any case, spaces ignored).
          Anything else is rejected and the same question stays on screen.

Pricing (per full hour, by the hour it starts)
----------------------------------------------
Hours 0-6 and 21-23 : 500
Hours 7-13 and 19-20: 1000
Hours 14-18         : 1500
Example: 6 to 8 -> 500 + 1000 = 1500.

Mushroom decision tree
----------------------
Ring?  yes -> Grows in forest?  yes -> Amanite tue-mouche
                                no  -> Convex cup?  yes -> Agaric Jaunissant
                                                    no  -> Coprin chevelu
       no  -> Gills?            no  -> Cepe de bordeaux
                                yes -> Convex cup?  yes -> Pied bleu
                                                    no  -> Girolle

This is a classroom exercise, not a real-world mushroom safety guide.
