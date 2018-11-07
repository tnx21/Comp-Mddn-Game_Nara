#### Name: Sean Herbert
#### Username: Herbersean
#### Animal Role: Owl
#### Primary Project Responsibility: Audio and dialogue management

## Code Discussion: 

Task | Contribution 
------- | ---------
	Dialogue | All
	DialogueTrigger | All
	DialogueManager | All
	Sound | All	( Prototype_1 > Assets > Audio )
	AudioManager | All	( Prototype_1 > Assets )
  
### Most interesting code I worked on:

https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/Scripts/Sean's%20Scripts/DialogueManager.cs


The whole dialogueManager was quite interesting as originally I thought this was just going to be used during the gameplay so it was set up in a particular way that worked. Eventually the idea of a cutscene was added and I was asked to make this work for not only in game and during the cutscene too. The cutscene required a decent change in the way that it worked and because the in game stuff was already done and we were short of time by this point, I just made it work for both implementations. This in turn caused a bit of complication as I ended up having to use my dialogue manager to switch from cutscene, to game, to cutscene, to main menu. I wish this could have been done in a more universal way, but instead we ended up with multiple cases with multiple outcomes (is it startScene? endScene? isFinalDialogue?).


### Most Proud of code:

https://github.com/tnx21/Comp-Mddn-Game_Nara/blob/master/Prototype_1/Assets/AudioManager.cs

One part of code in particular I am proud of is the carry over of the audioManager and its music from the main menu to the first cutscene, but then creating a new one for the game and destroying the old one, then deleting the game one and going back to a cutscene/ menu version. I felt this was quite cool because I was taking it step by step and I was only trying to make cases for the switch from menu to first cutscene and then to game, but before I could test this, I had a feeling it could end up looping well because of the instance being destroyed, it would then return state back to its initial point and set the end cutscene to be the instance again. This turned out to be the case and worked really well.


### Things I learnt from this project include:

Using github better as we had a few merge conflicts and sometimes the scene would change when I did not intent for it to do so. So learning to add things individually meant I could ignore the scene changes and avoid screwing up my team mates, and once I push everything else, I could “git reset –hard” and have a clean working tree again.

Learning how to use unity as a whole was great! I had never used it before. It was fairly easy to pick up, there is plenty of online tutorials (“Brackeys” the youtuber being my favorite), the amount of cool things you can do in unity is awesome.
I had also never done any coding in C# and having experience with many languages and development platforms makes me feel more confident as a software developer.


### The most important thing I will use in future projects:

My knowledge in C# with unity. In the beginning I struggled to grasp the concept of it, and figuring out how to reference objects or classes inside my scripts was really confusing. Once I learned that public and private variables had different uses as compared to java, the whole thing became clearer.
