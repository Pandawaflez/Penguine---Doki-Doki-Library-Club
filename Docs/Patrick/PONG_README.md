# UIElementHandler

## Overview

This asset is a 2D pong game designed to be an easy-to-use and customizable minigame for Unity developers to add to their games. It includes an AI opponent, scoring system, paddle and ball assets and buttons and code for mobile implementation. Ideal for quick prototyping, learning purposes, or as a starting point for a larger project.

## Features

-   **Feature 1**: AI Opponent that uses the ball's Y-axis to determine where to go. It is tricky to beat!
-   **Feature 2**: Scoring system that utilizes the factory pattern to be easily and readily customized and extended.
-   **Feature 3**: Two game modes, BC and Normal mode.

## Requirements

-   **Unity Version**: Unity 2022.3.42f1 or later
-   **Platform Compatibility**: Works on Windows, macOS, Android, iOS
-   **Dependencies**: None

## Installation

1. **Download the asset package**: Download the latest release from the Github repo or Unity Asset Store
2. **Import the package**:
    - Open Unity, go to `Assets > Import Package > Custom Package`.
    - Select the downloaded `.unitypackage` file and click **Import**.
3. **Add the prefab**: Drag and drop the main prefab (`PongGame.prefab`) from the `Assets` folder into your scene.

## Usage

### Basic Setup

1. **Drag the prefab** into your scene from the `Assets` folder.
2. **Position and scale**: The scene comes in 16:9 aspect ratio, perfect for scaling to all platforms. However you can change the positions and scale of each item in the unity editor if needed.
3. **Play the demo**: Press `Play` in the Unity Editor to test the prefab’s functionality.

### Customization

-   **Adjust Settings**: Open the prefab and adjust properties in the Inspector, such as:
    -   Positions of each element in the prefab
    -   Assets of the ball, paddle, background, scores, and game over screen.
-   **Script Modifications**: If needed, edit the attached scripts to add custom behavior.

## FAQ

**Q: How do I adjust the score limits?**  
A: You can adjust the score to win by setting the `PONG_SCORE_TO_WIN` variable in the `Pong` script. You can set this value to a maximum of 255. You can also update the score in the `Pong.cs` script by changing the variable initilzation as well.

**Q: Can I add additional levels?**  
A: Yes, you can add other mini game levels. You can create another subclass of the `MiniGameLevel` and update/add all the necessary functions for your neew game. Then, you then can create a new subclass of `ScoreManager` to handle the scoring system for your new mini game.

**Q: Can I update the speed of the paddles?**
A: Yes, you can update the speed of the paddles by going into the `Paddle.cs` script and changing the `speed` variable to whatever you would like. By default, it is set to 10.

**Q: Can I update the base and maximum speed of the ball?**
A: Yes, you can update the maximum speed of the ball by clicking on the `Ball` sprite in the Unity editor. There is a variable attached to the sprite called `Speed` which is the base speed. It is set to 5 by default. To update the max speed of the ball, you can update the other variable in the editor called `BALL_MAX_SPEED` to whatever you like. It is set to 15 by default.

**Q: Can I update the sprites**
A: Yes, you can update the sprites in the mini game. To do so, you can click on the element you want to update in the hierarchy, and drag and drop your new sprite into the `Sprite` tab in the `Sprite Renderer`.

**Q: How do I set up Mobile?**
A: The Pong game automatically detects if it is running on an Android or iOS device, and will enable the buttons for you. There is no setup or extra work required of you to do so.
