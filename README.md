# NintenTools.MarioKart8

This is a collection of .NET libraries and tools to handle typical Mario Kart 8 file formats, wrapping them in object oriented libraries and programs to handle them, closely trying to resemble what the original game developer tools might have provided to create the files.

The library is available as a [NuGet package](https://www.nuget.org/packages/Syroot.NintenTools.MarioKart8).

Usage
=====

Right now, the following usage cases are possible:
- Loading, modifying and saving the contents of **objflow.byaml** with the help of `ObjDefinitionDb`.
- Loading, modifying and saving the contents of a **&ast;_muunt&ast;.byaml** file with the help of `CourseDefinition`.
- Dumping the contents of **&ast;.bin** files.
- Loading the contents of **Performance.bin** into strongly typed structures.

Tools
=====

The repository contains the following command line tools. Please note these were developed for testing purposes and do not receive support.
- **Adjust200**: Takes a **course_muunt.byaml** and adds `Adjuster200cc` Objs into it from a **course_muunt_200.byaml** file in the same directory, overwriting the latter to create a new 200cc BYAML file.
- **BinDumper**: Dumps the data of **&ast;.bin** files as found in their section, group and element hierarchy.
- **NoLakitu**: Removes `EnemyPath` and `LapPath` from a **&ast;_muunt&ast;.byaml** (and Objs having referenced those) in order to get rid of Lakitu who would prevent you from going out of bounds.
- **ObjDumper**: Dumps the information found in **objflow.byaml** into a readable table.
- **Performance Editor**: Shows physics and point set details of a 4.1 **Performance.bin** file and allows editing and saving new versions.
![Performance Editor](https://raw.githubusercontent.com/Syroot/NintenTools.MarioKart8/master/doc/readme/performance_editor.png)
