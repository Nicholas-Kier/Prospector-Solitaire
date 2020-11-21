# Prospector-Solitaire
CSC476
Nicholas Kier

This project is pulled from Introduction to Game Design, Prototyping, and Development: From Concept to Playable Game with Unity and C#, 2nd Edition by Jeremy Gibson-Bond. 

Lessons Learned: 

XML Schema Documents are really neat! This was one of the biggest projects I've done for my undergrad studies, and it was definitely a great lesson in debugging
and understanding how to use the powerful tools part of Visual Studio. Great feeling to see this project slowly come together, until...

Challenges: 

I struggled immensely with debugging, specifically with one bug that should have been easy to fix...I was following the code from the book to a T, constantly checking my work
and making sure that I wasn't missing anything. As you can see from playing the game on Unity Connect...the sprites for the cards don't render properly most of the time. It's an
extremely frustrating bug, because it's always different when previewing the build inside Unity itself. Even worse, I knew exactly where to check this bug. It's easy to fix when 
you're running the game, it's a numerical setting under the SpriteRenderer method (specifically _tSR.sortingorder() in prospector.cs and 'order in layer' from the inspector panel
inside Unity) If you changed 'Card_Front' to layer 0, the cards properly render. I tried changing every numerical value inside of prospector.cs but could not understand why the
rendering was inconsistent.
