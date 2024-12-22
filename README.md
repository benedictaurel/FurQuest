# <p align="center"><img src="https://hackmd.io/_uploads/Hyu6VjBryl.png" width="400"></p>

**Fur Quest** is a 2D platformer game that tells the challenging journey of a fox father named Reynard, determined to reunite with his child. Throughout the journey, players will face dangerous monsters, leap over obstacles, and collect fruits to restore energy. With a modern pixel art style and a colorful world, Fur Quest will test players' agility and strategy in completing each level.

## 🏛️ Design Pillars
### 🔹 Main Game View
Fur Quest is presented in a 2D side-scrolling perspective. Players will see the fox character move left and right, as well as jump (up and down).

### 🔹 Core Player Activity
The main objective for players is to help the fox father Reynard reach his child by:
- **Jumping Over Obstacles**: Players must navigate platforms and obstacles such as cliffs, bridges, or ladders.
- **Avoiding and Defeating Monsters**: Players must avoid contact with monsters to prevent health points loss. Initially, the player has 3 health points, meaning they can withstand up to three encounters with monsters before the game ends. Monsters can be defeated by jumping on them.
- **Healthpoint Recovery**: By executing certain jump tricks, players can collect cherries to recover lost health points.

### 🔹 In-Game User Interface
<img src="https://hackmd.io/_uploads/rk6lFjrByx.png" width="400">

## 🎮 Genre/Story/Mechanics Summary
### 🔹 Character Background and Game Mood
Reynard, the fox father in Fur Quest, is a brave and loving character devoted to his child. After hearing that his child needs help at home, Reynard immediately sets out to reach his child.

While the world of Fur Quest appears vibrant and colorful, monsters in the game are a threat to Reynard and will hinder his journey.

### 🔹 Gameplay Mechanics
- **Player Properties**
  - Can move left/right and up/down (jump)
  - Has 3 health points (HP)
  - Loses 1 HP and experiences knockback upon colliding with an enemy
  - Can defeat enemies by landing on their heads
  - Gains a jump-boost (1 extra jump) after defeating an enemy
  - Recovers 1 HP when collecting a cherry (if current HP is below 3)
- **Frog Enemy**
  - Can jump
  - Reduces 1 HP upon contact with the player
  - Can be defeated by jumping on its head
- **Opossum Enemy**
  - Moves left and right
  - Reduces 1 HP upon contact with the player
  - Can be defeated by jumping on its head
- **Pig Enemy**
  - Moves faster than other enemies
  - Reduces 1 HP upon contact with the player
  - Can be defeated by jumping on its head
- **Eagle Enemy**
  - Does not attack or move
  - Functions as a floating platform
  - Can be defeated by jumping on its head

## 🗺️ Level Design
Currently, Fur Quest has 2 available levels, each featuring different enemy types and cherry items. In Level 1, there is a portal that, when touched, takes the player to Level 2. In Level 2, there is a door object that allows players to restart the stage, and the house of Reynard's child serves as the game's final goal.

### 🔹 Level 1
<img src="https://hackmd.io/_uploads/rk5PcsBB1x.png" width="400">

### 🔹 Level 2
<img src="https://hackmd.io/_uploads/Hygq9irBkl.png" width="400">

## 🕹️ Interface
### 🔹 Player Controls
| **Button**       | **Action**               | **Game State**        |
|-------------------|--------------------------|-----------------------|
| Any key           | Start game               | Main Menu             |
| W, D             | Move player              | In-game               |
| Spacebar         | Jump                     | In-game               |
| A, S             | Climb/descend ladders    | In-game, at ladder    |
| Spacebar         | Release ladder           | In-game, at ladder    |

### 🔹 Player Interactions
| **Object/Entity** | **Interaction**                     | **Response**                                                          |
|--------------------|-------------------------------------|------------------------------------------------------------------------|
| Enemy (all types) | Contact from the side               | Player loses 1 HP                                                     |
| Enemy (all types) | Contact from above                  | Enemy dies, player gains a jump-boost                                 |
| Cherry             | Contact                            | Restores/adds 1 HP if current HP < 3                                  |
| Portal             | Contact                            | Player proceeds to the next level                                     |
| Door               | Contact                            | Player respawns (restarts the stage from the beginning)               |
| Ladder             | Press A/S                          | Player enters climbing mode                                           |
| Ladder             | Press Spacebar                     | Player exits climbing mode                                            |

## 🎵 Music/Sound Assets
| **Type** | **Description**            | **Usage**                            | **File Name**             |
|----------|----------------------------|--------------------------------------|---------------------------|
| Music    | Main Menu Music (loop)     | Background music for Main Menu       | hurry_up_and_run.mp3      |
| Music    | Overworld Music (loop)     | Background music for Overworld level | Hurt_and_heart.ogg        |
| Music    | Underground Music (loop)   | Background music for Underground     | under the rainbow.ogg     |

## 👨‍💻 Group Members
#### 🔹 **Anthonius Hendhy Wirawan** - 2306161795
#### 🔹 **Benedict Aurelius** - 2306209095
#### 🔹 **Christian Hadiwijaya** - 2306161952
#### 🔹 **Jonathan Frederick Kosasih** - 2306225981

##
<p align="center"><b>FurQuest</b> © 2024. All Rights Reserved.</p>