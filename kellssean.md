# COMP313 Individual Report

##### Name: Sean Kells
##### Username: kellssean / Guest User / Sean Kells / SoBrodacious
##### Animal Role: Bear
##### Primary Role: Project Ownership, Team Leader

<br>

### Code Discussion:

For this project, I have been involved in the following areas of code

[AdvancedMovement.cs](https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Sean's%20Scripts/AdvancedMovement.cs) | [SOME] :

For the AdvancedMovement, I have been responsible for adding initial code that would allow for the player to pick up objects, and have those pickups affect player abilities. I also had a small part in refactoring this code.

[LeafRandomiser.cs](https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Prefabs/Terrain/Trees/LeafRandomiser.cs) | [ALL] :

For the LeafRandomiser, the objective was to create a varied environment with minimal manual editing. The idea of attaching a script to an object to randomise apprearanceof the hundreds of trees in an early scene at runtime was not instantly apparent, but allowed for a simple solution to our recurrent assets. The fact that this script could be attached to a prefab object allowed us to quickly populate our scene with trees which were just different enough from each other to be not noticable as prefabs.

[LiftBehaviour.cs](https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/LiftBehaviour.cs) | [ALL] :

In order to create a lift area which could have varied upwards thrust depending on the players proximity to origin, I created this script. While I have tried to make this script as extensible as possible, the range and force component of the script could be extended further to automatically be assigned on runtime, based on player and the attached lift collider

[PickupHandler.cs](https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Sean's%20Scripts/PickupHandler.cs) | [MOST] :

For the PickupHandler, I have been responsible for the initial code, as well as adding the necessary Pickup prefab objects in the Unity editor. 

While not particularly interesting, this section of code is the one that I am most proud of, as I was able to identify an optimisation that my fellow team members missed, in that attaching this script to the player object, rather than to the pickup itself, would save in calculation costs. While negligible in our project, with three pickups total, if there had been significantly more pickups, having a set of collision checks on each and every one of these stationary actors would have been more computationally expensive than having a single set of collision checks on the player each frame.

[Respawner.cs](https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Respawner.cs) | [Half] :

For the Respawner, I wrote the original code, prepared a test scene, and created Respawn prefab objects, which were later adapted by my team to include features such as playing sound on death, and interacting with the UI to display current lives. This code allows the player to interact with both mainspawns and subspawns for respawning purposes, as well as implements a life system to add some challenge to the game loop.

This section of code is my most interesting, as it allows for us as developers to create an interesting gameplay loop, wherein players can attempt a section multiple times, and upon failing, are only reverted to their most recent MainSpawn, rather than to the beginning of the game. This reduces the risk of experimentation and exploring while not entirely removing consequence, leading to interesting challenge for the player. 

### Learning Reflection

Perhaps most useful to me through this half trimester has been the experience of managing a multidiciplinary team. While not easy, and perhaps not properly done, I have gained useful insight into working in an iterative fashion with a mix of both programmers and designers, and how to best manage team work in order to meet project objectives.

In terms of programming skill, I am now comfortable working with C#, scripts, and more Unity related issues such as how to change attributes of a prefab at runtime by script. I have also had the chance to work with level design in the Unity engine, and how to use Unity's prefab system to create powerful templates for game objects.

My biggest takeaway from working in Unity in terms of programming is how to interact between scripts. The fact that this is a possibility, and that scripts can either be referenced by each other, or script methods globally by the use of an event manager has opened the door to a large amount of more complex and interesting mechanical interactions in gameplay.


