# Nara

## Game Loop

The game starts off in the main menu. Once pressing play it takes you to the first cutscene. After the cutscene it takes you to the game. Once the game is finished, you are returned to the main menu, where you can choose to play again. At any point in time within the game, you can pause the game to then restart the game or take you back to the main menu. 

## Level Structure

The idea is for the player to start off with just simple movements such as moving left and right and a single jump.
As the player explores the world they unlock more movement abilities which allows the player to explore more areas,
and unlock more abilities.

The game starts off in a cutscene to give background on what is happening. After the cutscene, the player enters the game and has a chance to explore and get a feel of the controls. The player is guided through the game with dialogue cues on what is happening and how to overcome obstacles. As Nara progresses through the level, she unlocks abilities which introduces more mechanics to the game. Once the game is finished, it goes back to the menu, where the player can choose to play again. 

## Controls

Use A and D to move left and right, use S to ground slam, and use space to jump and double jump. Double tap A or D to dash in a certain direction. 

Use ESC to pause the game at any point in time. 

Only movement with A, D and space are available at the beginning of the game. Once more movement mechanics are unlocked, the player will be informed on how to use them in game. 

## Challenges

One of the biggest challenge we faced was issues with merge conflicts using git. Unity on git doesn't seem to allow multiple people to edit the same scene, even if you are working on different sections. As we decided to have only one main level/scene, it was difficult when multiple people tried working on it. 

Another challege was implementing the new character model with the current controls. The main controls had a few bugs which ended up working really well as features. As the controls worked well and many people liked the mechanics of the game, we had to construct the new character and animations to work with and compliment the "bugs" without changing the actual mechanics of it. This was especially prevalent with the wall jumping. The movement script had to be adjusted to work with the new model without actually changing how it works. 

## Installation and Setup

To build and play the game in Unity:
* Clone the repository 
* Open Unity3D
* Select Open
* Navigate to clone repository, open it and select Prototype_1
* Go to Assets -> Scenes -> Menu.unity
* Play

<b>NOTE: Some of the assets may be missing due to issues from importing blender files. If you want to play the game on windows, please follow the windows build instructions. </b>

To play on Windows:
* Clone the repository
* Extract Windows Build.zip
* Double click Nara.exe

<b>NOTE: The Windows version is using some different assets than the Mac build because of blender importing issues. We prefer if you use the Mac build since it has all the proper assets. However, the Windows build does work properly if you do not have a Mac.</b>

To play on Mac:
* Clone the repository 
* Extract Mac Build.zip
* Double click Mac Build.app

## External Assets Used

Along with the Unity Standard Assets, this project has used a number of assets and tools from the Unity Asset in creating the game level, these include:

* [Blockout](https://assetstore.unity.com/packages/tools/level-design/blockout-100388)
* [GameObject Brush](https://assetstore.unity.com/packages/tools/utilities/gameobject-brush-118135)
* [GitHub for Unity](https://assetstore.unity.com/packages/tools/version-control/github-for-unity-118069)
* [GitMerge for Unity](https://flashg.github.io/GitMerge-for-Unity/) (GPL2.0)
* [Stones and Buried Treasure](https://assetstore.unity.com/packages/3d/environments/fantasy/stones-and-buried-treasure-95557)
* [TextMesh Pro](https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126)
* [Treasure Set - Free Chest](https://assetstore.unity.com/packages/3d/props/interior/treasure-set-free-chest-72345)
* [Kino Glitch](https://github.com/keijiro/KinoGlitch)
* [Menu song](https://soundimage.org/fantasywonder/)
* [Game song: Marcos H. Bolanos The Dream](http://freemusicarchive.org/member/AJStetson/Atmospheric_Magical_Expansive_Fantasy)
* [Other various sounds](https://freesound.org/people/tnx21/downloaded_sounds/)

## Developer files

Waseem Koya (koyawase): https://github.com/tnx21/Comp-Mddn-Game/blob/master/koyawase.md

Sean Kells (kellssean): https://github.com/tnx21/Comp-Mddn-Game/blob/master/kellssean.md

Sean Herbert (herbersean): https://github.com/tnx21/Comp-Mddn-Game/blob/master/herbersean.md
