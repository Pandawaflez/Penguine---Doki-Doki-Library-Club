# Charlie

## Overview

This asset is a Charlie Brown love interest character that is interactable through dialogue and responses. Depending on what response button
the user selects, it leads Charlie to a new dialogue. This also updates Charlie' affection points for the user

## Features

-   **Feature 1**: The sprite for the love interest Charlie Brown.
-   **Feature 2**: Displays Charlie's very accurate dialogue.
-   **Feature 3**: Two response options which impact the dialogue and affection points, creating a very interactive experience!

## Requirements

-   **Unity Version**: Unity 2022.3.42f1 or later
-   **Platform Compatibility**: Works on Windows, macOS, Android, iOS
-   **Dependencies**: None

## Installation

1. **Download the asset package**: Download the latest release from the Github repo or Unity Asset Store
2. **Import the package**:
    - Open Unity, go to `Assets > Import Package > Custom Package`.
    - Select the downloaded `.unitypackage` file and click **Import**.
3. **Add the prefab**: Drag and drop the main prefab (`Charlie.prefab`) from the `Assets` folder into your scene.

## Usage

### Basic Setup

1. **Drag the prefab** into your scene from the `Assets` folder.
2. **Position and scale**: The scene comes in 16:9 aspect ratio, perfect for scaling to all platforms. However you can change the positions and scale of each item in the unity editor if needed.
3. **Play the demo**: Press `Play` in the Unity Editor to test the prefab’s functionality.
4. **Dependencies**: The `Charlie.cs` script should already by attached to the Charlie sprite, and all additional configurations set. Additionally, `Charlie.cs` is dependent on the `Peanuts.cs`, `PeanutsDB.cs`, and `Dialogue.cs` files.

### Customization

-   **Adjust Settings**: Open the prefab and adjust properties in the Inspector, such as:
    -   Positions and sizes of the dialogue in relation to Charlie
    -   Assets of Charlie, the dialogue, and responses.
-   **Script Modifications**: If needed, edit the attached scripts to add custom behavior.

## FAQ

**Q: How do I change the dialouges and/or responses?**  
A: You can adjust dialogues by changing the dialogue strings in the `CharlieDialogue` class in the `Dialogue.cs` file. You can change the dialogues to whatever you would like, as well as the response options. To change the order of conversation, you will have to edit the `toNextDialogue()` function in the `Charlie.cs` script. Each switch case is the dialogue that Charlie is on, and the `p_dialogueNum` indicates which response was just hit. You can change the `p_dialogueNum` to whatever new dialogue you want to go to.

**Q: Can I add additional dialogues?**  
A: Yes, you can add other mini game levels. Just like the instructions above, you can add additional dialogue strings in `Dialogue.cs`. You will then have to add the corresponding switch statements in `toNextDialogue()` in the `Charlie.cs` script, following the same logic. You will also have to update `v_displayDialogue()` in the in the `CharlieDialogue` class in the `Dialogue.cs` file. Simply add an additional case and call `displayRealDialogue()` with the new strings you wrote.

**Q: How do I change the affection points?**
A: You can edit the progression of Charlie's affection points in the `toNextDialogue()` function in the `Charlie.cs` script. Any call to `updateAffection()` can be passed a different integer that updates his affection.

**Q: What does BC Mode do**
A: BC Mode makes it so Charlie's affection points are easier for the player to gain. His affection points will never go down to a negative responses, and any positive responses increases his affection by twice the normal amount.

**Q: Can I update the sprite?**
A: Yes, you can update the sprite. To do so, you can click on the Charlie in the hierarchy, and drag and drop your new sprite into the `Sprite` tab in the `Sprite Renderer`.

**Q: Can I change the dialogue and response button displays?**
A: Yes, you can change the appearance of the dialogue and responses. To do so, click the elemtn you want to update in the hierarchy, and change the settings as desired in the Inspection window. Note that relative sizes are locked in order to ensure the dialogues and buttons display correctly depending on window size changes, so you can only edit actual panel sizes en masse through the `Scale` variable in `DialoguePanel`.

