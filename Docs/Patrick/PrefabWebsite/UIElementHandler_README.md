# UIElementHandler

## Overview

The UIElementHandler is a customizable UI system built with the singleton pattern that manages UI elements in your game, including a pause screen overlay that has features for adding/removing score elements and end game screens. This system also includes mobile implementation support for the overlay by including a button for pausing/stats when your game is run on mobile.

## Features

-   **Feature 1**: Public accessor instance, allowing other separate components to make calls for UI popups.
-   **Feature 2**: Overlay/Pause screen that supports the addition and removal of score/point meters.
-   **Feature 3**: Overlay button that appears when game is running on Mobile ('Tab' on PC to show overlay).
-   **Feature 4**: Quit button appears when overlay comes up, simulating a pause screen.
-   **Feature 5**: Endgame screens with customizable win/loss text (public accessor methods).

## Includes

    - UIElementHandler
    - Canvas
    - Overlay (panel)
    - EndGame (panel)
    - Quit Button
    - Overlay Button (for mobile)

## Requirements

-   **Unity Version**: Unity 2022.3.42f1 or later
-   **Platform Compatibility**: Works on Windows, macOS, Android
-   **Dependencies**: CandyCoded Package for Mobile implementation

## Installation

1. **Download the asset package**: Download the latest release from the Github repo or Unity Asset Store
2. **Import the package**:
    - Open Unity, go to `Assets > Import Package > Custom Package`.
    - Select the downloaded `.unitypackage` file and click **Import**.
3. **Add the prefab**: Drag and drop the main prefab (`UIElementhandler.prefab`) from the `Assets` folder into your scene.

## Usage

### Basic Setup

1. **Drag the prefab** into your scene from the `Assets` folder.
2. **Position and scale**: The scene comes in a flexible aspect ratio, easily implemented on all platforms.
                            - Information on how to adjust the sizing/position of score elements below in FAQ.
3. **Add scoring elements**: Add images to the UIElementHandler gameobject in the inspector to assign images to score meters in the overlay.
                            - For every image/element you want to add to the score overlay, you must also add to the UIElementHandler script.
                              (details for this in FAQ).
4. **Assign elements**: In the inspector, ensure gameobjects are assigned.
3. **test features**: Press `Play` in the Unity Editor to test the prefab’s functionality.
                            - Test for overlay popup functionality and end game screens.

### Customization

-   **Adjust Settings**: Open the prefab and adjust properties in the Inspector, such as:
    -   Positions of each element in the prefab 
    -   Assets of the score element images and other onscreen buttons.
-   **Script Modifications**: If needed, edit the attached scripts to add custom behavior.

## FAQ

**Q: How do I add/remove point meters in the overlay?**  
A: For every scoring element you want to add or remove, there are two steps:
    1. Add/remove an element from the Character Images inspector window within the UIElementHandler gameobject (make sure to assign the proper sprite as well).
    2. Also add/remove a corresponding string from the `_characterNames` string array within the `UIElementHandler.cs` script. This is used for identification of the individual score elements on the overlay. 

**Q: How do I modify the sizing/position of the score elements on the overlay?**  
A: The overlay panel itself always starts out blank, with no child objects until the singleton is initialized. In order to adjust the sizing, spacing, and positioning of the elements on the overlay, modify the values within `UIOverlay.cs`. There are methods for each part of the scoring element (image, progress meter, and points text) within this script, and rect transform code within these functions determine the size, padding, and positioning of the elements.

**Q: Can I change the colors of elements shown in the overlay?**
A: Yes, similar to modifying the size and positioning of elements on screen, `UIOverlay.cs` also contains code for the modification of color values that are easily modifiable.

**Q: How do I change the end game screen text?**
A: The script `UIElementHandler.cs` contains 2 methods that handle the appearance of the win and loss screens. Simply modify the text within the quotations to your specific needs.

**Q: How do I use the Global Accessors?**
A: UIElementHandler initializes a global access instance called `UIGod` (you can change the naming if needed). Through this instance, you can call any of the public functions within `UIElementHandler.cs` from anywhere as long as the singleton is present in the current scene. For instance, to call the lose game method from another script: ` UIElementHandler.UIGod.LoseGame(true); `

**Q: How do I set up Mobile?**
A: UIElementHandler automatically detects the current build platform of the game, displaying a button to display the overlay when on mobile. To get haptic feedback working for some features, modify ` UIElementHandler.cs `:
    - Uncomment ` using CandyCoded.HapticFeedback; ` (you will most likely have to install the CandyCoded haptic feedback package from GitHub into Unity: ` https://github.com/CandyCoded/HapticFeedback?tab=readme-ov-file `).
    - Also Uncomment methods relating to CandyCoded Haptic Feedback within the script. These methods can be removed and added to any point in the script for your desired purposes.
