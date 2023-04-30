# CISC-3667-Lab-Project

Lab project repo for CISC3667 Spring 23

## Requirements

- Layered background (background/foreground)
  - Each scene has this. Hills has a tree, Desert has cacti, and Cave has stalagmites.
- At least one image
  - There are plenty of images used in the game, for basically everything on screen
- A player-controlled sprite
  - The player controls an adventurer character
- A balloon sprite with automatic movement
  - I decided to use birds instead of balloons in order to fit my setting better
  - Birds actually fly using physics and upward forces when flapping
- The ability for the player to shoot pins at the enemy
  - Player throws fireballs instead of pins cuz it’s way cooler
  - Fireballs are physically simulated
  - Rotated to match their current velocity for clear arcs and trails
- Collision detection of pins, using tags so that a player does not pop himself with his own bullets
  - Fireballs collide and destroy
  - If colliding with a bird, the bird drops dead
  - Uses physics groups to avoid collisions with player
- Sound effect on collisions
  - Fireball has a sound when thrown and another when impacted
  - Birds have a sound when they die
- Displayed score for player
  - Score is displayed on top left
- Increasing size of balloon and impact on score
  - Increase in size doesn’t make sense for my birds, so instead they fly higher over time
  - Hitting the bird while it is higher up rewards more points, incentivizing players to take risks and let the birds rise
- At least one distractor
  - Airplanes that fly overhead, blocking your fireballs
  - They also have a smoke spritesheet particle system for extra flair and visual distraction
- At least three levels in increasing order of difficulty. Document the difficulty of each level in the directions.
  - The birds spawn more rapidly and fly faster every level up
- Scene transitions: Every time that your player pops the balloon, the game should transition to the next level. Every time the balloon gets too big and disappears, the current level should be restarted.
  - Instead of transitions every single time they hit a bird, it transitions at thresholds that get exponentially larger each level
  - When a bird escapes off the top of the screen, it sends you back to the menu
- Directions (include the basics of each level)
  - From the menu, you can access the help screen
- Settings, including a volume setting with a slider
  - TODO
- Menu
  - Includes animated title, play button, help button, and high scores
- Pause/resume and link back to menu
  - Pause/Resume is on bottom right, menu button is bottom left
- Some other UI (dropdown, toggle, input)
  - TODO
- A data item that persist from scene to scene
  - Score persists
- A second data item that persists
  - Player username persists
- High scores (at least 5, presented in order)
  - TODO
- Animation #1
  - Player has idle, walking, and jumping
- Animation #2
  - Bird has flying and dead animations
- Extra credit(?) Animation #3 & #4
  - Fireball has animation and trail
  - Airplane has animated smoke particles
- Extra credit: difficulty selection by player (with documentation about difficulty)
  - TODO
