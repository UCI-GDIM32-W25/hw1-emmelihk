# HW1
## W1L2 In-Class Activity

- UI
  - Seed counter (planted and remaining)
  - Planted text
    - Every time something is planted, add 1 
  - Remaining text
    - Every time something is planted, subtract 1 to a limit of 0
- Plant Prefab
  - Plant sprite
  - Can be planted if Seeds remaining counter >0
  - Can only be created by the player
  - Only 5 can exist
- Bunny (Player)
  - Bunny sprite
  - Can move with WASD
  - Plant seeds with Space bar
    - Adds a plant prefab where the bunny is located IF there’s seeds remaining
    - If no seeds remaining, cannot plant (nothing happens)
    - Updates UI with changes to seed count and seeds planted

## Devlog
So... I tried to follow the plan and add things in one by one kinda, but I ended up... not knowing like. anything...

Even in office hours I was super confused. I'm trying to catch up now, but to be honest, I really don't understand methods or classes at all... I just learneed what a quaternion identity is (which means no rotation) and learned where to put it. 

I’m using the in-class guide to match to the three main things I need to tackle, the player, the planting, and UI. Maybe my group and I did it wrong, but we didn’t really lay out a plan I don’t think. For me, trying to plan out how I do this (as I’ve already attempted once and did not succeed), I’m going to try and use my bean to make things go smoothly. 

Within what we’re given, we’re already given the Player class and its MonoBehavior (which I’m a little confused at what the monobehavior is… I think it’s something to tie things in the script together… but maybe it doesn’t matter rn). I know in this script I need to, (1) move the player with WASD, (2) Plant a seed when pressing space bar, (3) adjust the UI when planting. 

(1) Moving the player
- My initial plan for doing this is to use the KeyCode for WASD, I think there’s also something with Input.GetAxis or something, but it didn’t work last time, so I’ll try this new method.

(2) Planting a Seed 
- This is where things start to go downhill. I know I need to “instantiate” the plant prefab, but before this class I forgot instantiate was a word… (off to a great start as you can see). Instantiating is (according to Unity YouTube tutorials) a function used to create clones of objects. So step 1. I make the plant a prefab. Then I need to make the PlantSeed function by instnatiating the plant, I do this by putting Instantiate(plantPrefab); in the PlantSeed() function. Then when I call the function, in void Update(), I’ll run a few if conditions to check if they match the assignment parameters. 
- In Update, I’ll use if to check how many seeds have been planted and how many more can be planted? This is where I need to change tasks and check on my private variables, _numSeedsPlanted and _numSeedsLeft. Neither of them have been given any value, only declared. But these are connected to the actually declared and defined variable, _numSeeds, which has been given the value of 5. 
    -  So first, I need to think of how to connect these. _numSeeds needs to be constantly updated and has to be subtracted from– but where should I do those subtractions? In the function or in the if loops? (After asking my boyfriend what to do I realized my question was already answered). If it was in the function, would it actually run every time? And what would stop it from being overused? I think the simpler way is to use it in the if function (maybe)
    - So there’s a few things I need to check before planting a seed? 1. How many seeds are in _numSeeds? —> if space bar has been pressed && _numSeeds > 0, plant seed AND _numSeeds = _numSeeds - 1; 
        - In the same vein of thought, _numSeeds will also be used to update _numSeedsLeft and _numSeedsPlanted, which correspond directly to the UI
            - To update these, I’ll reference and define _numSeedsLeft = _numSeeds (this only works if its after the previous _numSeeds = _numSeeds - 1; is used first, so I have to be careful about that
            - _numSeedsPlanted will be added to the if function… so every time space bar is pressed (and if _numSeeds > 0, then _numSeedsPlanted will +1; so the if statement will be like 
            - if( space bar && _numSeeds > 0) { Instantiate(plantPrefab); _numSeedsPlanted = ++; }

(3) Updating the UI
- I think this is easy but also I’m a bit dumb when it comes to programming and confidence feels more like a false sense of security that will burn me later, so here’s my plan that will hopefully not burn to the ground!
- Somehow I need to communicate the updated _numSeedsPlanted and _numSeedsLeft numbers to the PlantUI script… I’m not actually sure how to do that. But maybe it will just… do it for me?
- We also have _plantedText and _remainingText, which seems a bit convoluted to me, but maybe this is the answer I’ve been searching for. 
- My theory is that these newly defined terms will talk to each other and update between scrips… I’ll come back to this if my theory is wrong…(I was wrong. Big surprise)

Start, Update, or Something Else?
In the beginning, I had a really hard time understanding the difference between update and start, and I couldn’t tell where things should be placed. Where should I be calling the plantSeed function? Where should I put the move controls? 

It makes sense now to think that putting demands in start will only make sense at the start of the game, but then what even goes into Start? Because if something is only useful when the first frame of the game is played, what point is there? The answer to this was defining variables, things that would update and change throughout the game, but always had the same starting value. 

GLOSSARY: 
1. Instantiate: a function that is used to create clones of game objects, typically used in the context of cloning prefabs | Instantiate(GameObject);
2. MonoBehaviour: a base class that many Unity scripts derive from.
3. Prefab: preconfigured object stored in the projects assets
4. Quaternion Identity: something weird about rotations


Following My Own Terrible Instructions:
1.  Step one in getting WASD was fine once I figured out how to do it (and not contradict keys like a bozo)
2. Planting seed… did not go as expected.  I FORGOT (TWO) yes two. Two big things. How to say where the plant would be planted and how to make it stop infinitely multiplying…)  
- To solve this, I added to the instantiate things Instantiate(plantPrefab, _playerTransform); (bc if it worked on the sprite surely, it has to work here as well… or so goes the logic)
    - This also ended up not working because then the plant just followed the player around LOL
- Then I asked a friend what to do and they told me to quaternion and it didn’t work bc it couldn’t convert smth into a vector3 and so I replaced it with a zero annnddd now it works! They also said to do this weird redefining thing to make the plant prefab a game object and ykw if it works, I won’t complain.
    - They told me to make a new plant prefab basically and then replace that as a game object, that way I could connect it to the vector3 and it would stop following the player around!!! (Woohoo)!!
3. WOW I WAS WRONG (such a big surprise ! (<— read with sarcasm)) I didn’t even notice that there were new strings in the UI thing so I adjusted to add those in and ALSO! Discovered ToString() and .text :thumbs_up_emoji: 
    1. The trouble now was getting the code to connect to the UI… I had to phone a friend for this…
        - New issue: the ui is still ##… I don’t know why this is.

        I GOT IT. ok the struggle was actually i had to like... change the script or smth and i thought my computer was about to explode but CRISIS AVERTED!!! 

        thank you to all the lovely people who helped me code this, actually could not have done this without you guys.

## Open-Source Assets
If you added any other outside assets, list them here!
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - character and item sprites

## Prof comments
I'm giving you full credit for this Devlog because it was very thorough. But just a note, the prompt asked you to connect your high-level breakdown to the code that you wrote, and although you did do that, it could have been a little more clear throughout. Also, technically what I'm looking for with these Devlog prompts is an accurate description of why your code *works*. That being said, this was very entertaining and useful for me to read, so I don't necessarily want to discourage you from journaling about your programming adventure, but I also want to emphasize that you may want to make separate sections in your next Devlog for 1) a final Devlog that VERY clearly and succinctly answers the prompt, and 2) a section for your thought process/ journaling/ notes. :)

A few clarification points, just in case this helps your learning process.. :)

> I really don't understand methods or classes at all...

Variables store little bits of data, like a status (how many seeds the Player has left) or a reference to another object (like the Player's reference to the PlantCountUI Component). Methods perform actions on variables and change the status of things, like how the PlantSeed method changes how many seeds you have left. Classes are blueprints for objects, and contain variables (data) and methods (things they can do to data).

> Maybe my group and I did it wrong, but we didn’t really lay out a plan I don’t think

I think your breakdown was fine in terms of describing behavior in the game, but I would have liked to see the breakdown in terms of objects, attributes, and actions.

> In the beginning, I had a really hard time understanding the difference between update and start

For every single Component, Start is called once, right when the game loads; and then Update is called every single frame. Games usually run at 30-60 frames per second; meaning, Update will get called a bunch of times per second. This Update loop is how games are simulated; they're constantly updating/changing as the player is playing them.

> Quaternion Identity: something weird about rotations

Truer words have never been said. (And this is all you need to understand about Quaternions for now.)

Please consider formatting your break-down activities with the hyphen '-' symbol as suggested above, and remove the prompts. This will make it a lot easier for me to read. See the [README formatting guide here](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax).
