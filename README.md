# NintenTools.MarioKart8

This is a collection of .NET libraries and tools to handle typical Mario Kart 8 file formats, wrapping them in object oriented libraries and programs to handle them, closely trying to resemble what the original game developer tools might have provided to create the files.

The library is available as a [NuGet package](https://www.nuget.org/packages/Syroot.NintenTools.MarioKart8).

Usage
=====

Right now, the following usage cases are possible:
- Loading, modifying and saving the contents of **objflow.byaml** with the help of `ObjDefinitionDb`.
- (Partially) Loading, modifying and saving the contents of a **&ast;_muunt&ast;.byaml** file with the help of `CourseDefinition`.

License
=======

<a href="http://www.wtfpl.net/"><img src="http://www.wtfpl.net/wp-content/uploads/2012/12/wtfpl.svg" height="20" alt="WTFPL" /></a> WTFPL

    Copyright © 2016 syroot.com <admin@syroot.com>
    This work is free. You can redistribute it and/or modify it under the
    terms of the Do What The Fuck You Want To Public License, Version 2,
    as published by Sam Hocevar. See the COPYING file for more details.
