# Adding a new skin
Please follow the steps stated in this document, in chronological order.

<br>

# Prerequisites
- At the time of writing this guide, the playable character in AstroRun has 5 distinct animations:
    - idle
    - walk
    - run
    - jump/land
    - die

> Any new skin, should support all of the animations mentioned above

- The animations may be of any framerate/length. As long as you make sure to adjust the animations accordingly, inside the animation window in Unity.

- Make sure every distinct animation, has it's own spritesheet containing all of the frames for that animation

<br>

# Adding the spritesheets
- Navigate to: `Assets/RiolRat/Tiles/_Characters`
- Create a new folder, with the name of the skin
- Create two subfolder, within the folder you just created
    - Subfolders:
        - `female`
        - `male`
- Create subfolders within each of the 2 gender folders you created in the step above. Every subfolder should contain one distinct animation. Ideally you should have 5 folders, that look as follows:
    - 1_idle
    - 2_walk
    - 3_run
    - 4_jump
    - 5_die
- Each of these 5 subfolders, contain the spritesheet with the animation
    > The import settings on the spritesheets inside Unity, aside from the resolution don't matter. Since we will pack all the spritesheets of a gender on one sprite atlas. Those import settings, apart from the resolution, will be overwritten.
- Configure the following for every spritesheet, before moving on:
    - Texture Type: `Sprite (2D and UI)`
    - Sprite Mode: `Multiple`
    - Click on *Sprite Editor*
        - Slice the spritesheet, to get all of the animation frames as seperate sprites
    - Pixels Per Unit: *Adjust this, until the skin has the same size as all of the previous skins*
    - Max Size: *As low as possible, without the sprites becoming pixelated/suffering from compression artifacts by crunching the sprite atlas they will be on*

# Creating the sprite atlas
- Navigate to: `Assets/RiolRat/SpriteAtlasses/Characters`
- Create two new sprite atlasses, one for each of the genders
- Apply the settings below:
    - Type: `Master`
    - Include in Build: `true`
    - Allow Rotation: `false`
    - Tight Packing: `false`
    - Alpha Dilation: `false`
    - Padding: *As high as possible. If by setting this option a lower value, you are able to fit all of the sprites onto the sprite atlas. Without having to increase the sprite atlas' `Max Texture Size`. Then you should do so.*
        > Note that setting the padding too low, might cause parts of sprites, to blend into other sprites
    - Read/Write: `false`
    - Generate Mip Maps: `false`
    - sRGB: `true`
    - Filter Mode: `Bilinear`
    - Max Texture Size: *As low as possible, whilest still being able to fit all of the sprites*
    - Format: `Automatic`
    - Compression: `High Quality`
    - Use Crunch Compression: `true`
    - Compressor Quality: `100`


# Adding the animations
- Navigate to: `Assets/RiolRat/Animations/Character`
- Duplicate the male/female folders of a previous skin
- Adjust the folder names
- The following steps should be done both for the female/male version of the skin:
    - From the command line, navigate to one of the 2 folders you just duplicated
    - Run the command below to rename all of the animations + the animator override controller
        ```
        for f in *hero_*; do mv -i -- "$f" "${f//hero_18/hero_30}"; done
        ```
    - Back inside of Unity, go over all of the animations + animator override controller. And click on *Fix object name* inside the inspector
    - Drag all of the animations one by one into the animator override controller

    <br>
    
    - Open the following scene: `Assets/RiolRat/Scenes/World 1/Level1.unity`
    - Select all of the animations, without the animtor override controller, and drag them onto the `Player` gameobject inside the *hierarchy*
    - Open the *Animation* tab
    - Click on the `Player` gameobject inside the *hierarchy*

    <br>

    1) Back inside the *Animation* window, change the selected animation to *\<skin name\>-1_idle*
    2) Navigate to where the sprite sheet of the idle animation for this gender is. 
    3) Click on the little arrow to "unfold" the sprite sheet, select all of the individual sprites
    4) Drag them into the animation window
    5) Adjust the `Sample` variable inside the animation window

    <br>

    - Repeat the numbered steps above, for all of the animations
    - Open the *Animator tab*
    - Click on the `Player` gameobject inside the *hierarchy* 
    - Remove all of the animations you added, by dragging them onto the `Player` gameobject a couple steps ago
        - The animations you have to delete, have the name of the new skins you added + they shouldn't be connected to anything inside the state machine
    - Don't save changes for the Level1.unity scene when prompted, since we didn't make any changes that we would like to keep

# Adjusting the scripts
- Open the following file: `Assets/RiolRat/Other/SkinsIDs.md`
- Add 2 new rows at the end of the table, one for each of the genders
- Do the following for each column of the new rows:
    - `Skin ID`: Increment the value of the last row, by one
    - `Skin Name`: Fill in the skin's name + its gender. This should be the same name you used when creating the subfolders inside the `Animations/Character` folder

---

- Open the following scene: `Assets/RiolRat/Scenes/MainMenu.unity`
- Inside the *hierarchy*, open the following gameobject: `Canvas > SubMenu_Shop_Skins > Shop`
- Unfold the `Skin Thumbnail` variable
- Click twice on the plus sign, at the bottom of the `Skin Thumbnail` variable's visualization, to add 2 skin slots
- Drag the first frame, of the idle animation of your new skin, into the new row you created. Repeat the same for the other gender of your new skin
    > Note: Make sure that the order in which you drag the skins, i.e. the order in which they appear in the inspector. Corresponds with the order in the *SkinsIDs.md* file you just edited.
    