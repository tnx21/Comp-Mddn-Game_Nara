#### Name: Waseem Koya
#### Username: koyawase
#### Animal Role: Cat
#### Primary Project Responsibility: Implementing features to do with character controller, animations and UI

## Code Discussion 

### Contributions

Task | Contribution 
------- | ---------
Advanced Movement | Most
Attach Player | All
Camera Shake | All
Main Menu | All
New Camera Movement | All
Pause Menu | All
Remove Rubble | All
Trap Door | All
Update Altar Trigger | All
Respawner | Some

### Most Interesting Code

#### Pause Menu

Script: https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Waseem's%20Scripts/PauseMenu.cs

One of the initial features we wanted to implement was a pause menu. This would allow the player to either take a break or restart or quit the game. 

The two things that I wanted to implement when pausing the game was showing an interactive UI overlay and freezing the current game state. 

Firstly, the UI implementation was simply achieved by switching the canvas on and off. The pause menu was mostly independent from the code, which made it really modular and easy to implement. Each individual button had a designated function in the script which made for low coupling and easily modular code. Once I learned how to enable and disable assets from the script, it opens the idea of creating a more dynamic and interisting game. 

Secondly, freezing the game state was done by setting the Time.timescale to 0. This froze the game in time. So if the player jumped and paused the game, the animation will stop and the player will freeze mid air. However, this does not disable the movement script. You can still press the movement buttons and they will register the input. Since the game is frozen, it will not move. However, when unpaused, all the inputs are registered and the player will move rapidly because of all the registered inputs since paused. This was fixed by actually disabling the movement script when paused. It was interesting to see that Unity had the ability to not only enable and disable in game objects, but also scripts. The Time.timescale could also be used in interesting ways. If set to 0.5, it would slow the game by half the speed allowing for features like slo mo and if set to 2, if would increase the game speed by 2 times. 

### Most Proud of Code

Script: https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Sean's%20Scripts/AdvancedMovement.cs

The code I was most proud of was the animations in the Advanced Movement script. The game started off with just a cube, but we wanted to implement a character model to replace that. I was a little bit sceptical about how that would work in the beginning. Firstly, because we were changing from a box collider to what would be a capsule collider. I wasn't sure how the physics would work and the affect to the overall gameplay when making the change. Secondly, because some of the features with the movement were actually bugs. It was going to be difficult to implement and transition animations for features that was actaully bugs and were hard to isolate. 

Changing from the box collider to the capsule collider worked rather well. The gameplay and mechanics of the actual player felt more smooth and fluid. 

I managed to get the animations working with the new character model. It took a long time playing with the animation controller and transitions within Unity and also getting the code to work within the script. Even though some of the features were actually bugs, I managed to get the animations working for all the movement mechanics. This was especially difficult for the ground slam and wall jump. By isolating each of the movement types, I was able to implement each of the animations and make the player movement with the new character model look and play as smooth as possible, without actually changing the core mechanics. 

## Learning Reflection 

### What I have Learnt 

From this project, I learnt how to create a game from scratch in Unity3D as well as various soft skills and management skills. 

I have learnt the importance of testing. I am quite used to regular unit testing, but with unity, that didn't really seem possible. I had made a number of small changes when it came to refactoring towards the end of the project. They seemed like relatively minor changes that wouldn't affect the actual game. Because of this, I didn't extensively test the changes. However, on the last day of the project, we realised there was a number of bugs within the game. I missed these because I didn't test it properly and if someone else didn't test it on the last day, we might have submitted the game with bugs we didn't even know was there.  

I have also learnt about managing the time and scope of projects. Initially, we wanted to implement much more features and I was willing to take on much more. However, I didn't realise how long some of the tasks would take and it would be infeasible to implement all of the features we wanted. By monitoring how much work we were actually able to get done, and determine what we actually needed to complete, we were able to come up with a completed game. This was thanks to managing our time and resources according to the scope we were looking to achieve. 

### Most Important Takeaway 

The biggest takeaway for me was learning how to work in a team with different skills and backgrounds. It was my first time working with designers and it was a little bit different than I expected. At times, I didn't know what was possible from them and they didn't know what was possible from me. It felt like we were speaking different languages at times. However, overtime we managed to match our skills and were able to work togther towards developing a final product. Communication ended up being the key to success of the project and it only got better over time. Whilst we didn't really know what to expect in the beginning, we came to a clear understanding of each others skills and abilities when it came to working together. 
