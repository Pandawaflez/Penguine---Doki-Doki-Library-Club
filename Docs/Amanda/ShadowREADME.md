# Interactable Unique Shadow Love Interest

## Overview
This asset offers a custom interactable scene with a selected character, i.e Shadow the Hedgehog where there are a provided list of dialogue choices Shadow uses and a list of dialogue responses the player is able to choose through button selection. Based on the given prompts, Shadow will favor one response over the other, if too many bad choices have been made, Shadow becomes locked. This asset is easily applicable to more than an affection point based system, where whenever a customized one on one interaction between a player and a non-playable character (NPC) is needed. 

## Features

-   **Feature 1**: Shadow Sprite Love Interest (NPC)
-   **Feature 2**: UI Dialogue Display System that includes a main dialogue textbox, two response button textboxes.
-   **Feature 3**: Fully integrated character specific state pattern for key game moments and overall flow of conversation
     - Ex: `ShadowLockoutState, ShadowNormalState, ShadowMiniGameDateState.`.
-   **Feature 4**: Affection points display updated through an observer pattern to see how each dialogue response affects the NPC's opionion of the player. 

## Includes
 ![image](https://github.com/user-attachments/assets/7b32e6ef-6bcc-44f8-84b6-d1003b0b84b1)
 -  Shadow
 -  AffectionManager
 -  DialogueManager
 -  ShadowDialogueDisplay
 -  ShadowDialoguePanel
 -  ShadowDialogueText
 -  Response1 Button
 -  Response1 Text
 -  Response2 Button
 -  Response2 Text
 -  AffectionLevel Text


## Requirements

-   **Unity Version**: Unity 2022.3.42f1 or later
-   **Platform Compatibility**: Works on Windows, macOS, Android, iOS
-   **Dependencies**: Ensure you have attached the script UnityDialogueUI to the DialogueManager Game Object and use the Inspector window to assign the needed components as pictured below. ![image](https://github.com/user-attachments/assets/40ace138-e195-4cc6-b5be-c4a13093a28b)
-   NOT INCLUDED: An EventSystem prefab, which is accessible through right-clicking on the scene, then UI->Event System.
-   Note: Make sure all necessary scripts (Hedgehog.cs, ShadowDialogue.cs, IState.cs, ShadowNormalState.cs, ShadowLockoutState, AffectionManager.cs, AffectionUI.cs, and IAffectionObserver) are included in an Assets folder. 


## Installation

1. **Download the asset package**: Download the latest release from the Github repo or Unity Asset Store
2. **Import the package**:
    - Open Unity, go to `Assets > Import Package > Custom Package`.
    - Select the downloaded `.unitypackage` file and click **Import**.
3. **Add the prefab**: Drag and drop the main prefab (`Shadow.prefab`) from the `Assets` folder into your scene as shown in the image below. 


## Usage

### Basic Setup

1. **Drag the prefab** into your scene from the `Assets` folder.
2. **Position and scale**: The scene comes in 16:9 aspect ratio, perfect for scaling to all platforms. However you can change the positions and scale of each item in the unity editor if needed.
3. **Play the demo**: Press `Play` in the Unity Editor to test the prefab’s functionality.

### Customization

-   **Adjust Dialogue Prompts and Responses**: Easily customize the lines to what you would like through editing the code directly in the sections pictured below of the ShadowDialogue.cs script. 
![image](https://github.com/user-attachments/assets/65e6bd0c-1b30-4527-ab91-b77217c5e53c)

-   **Change Colors on Buttons and Sprites**: Using the Unity Inspector window, click on the item you would like to modify, and simply change the color to your preference.
    -   Positioning of each element in the prefab.

-   **Script Modifications**: If needed, edit the attached scripts to add custom behavior like new states for certain affection point levels.
    -   Allows you to craft a unique love interest. 

-   **Difficulty Levels**: It is easy to implement different affection point scoring based on a given difficulty level. 

## FAQ

**Q: How do I adjust the affection points?**  
A: You can adjust the affection points to your heart's desire by editing the `ProcessChoice` method in the `ShadowNormalState` script. You can set the dialogue.affectionManager.ChangeShadowAffectionPOints(value) to any value you would like based on the given dialogue response. 

**Q: Can I add additional dialogue?**  
A: Yes, you can additional dialogue, including an extra dialogue box if wanted. You can also create another dialogue response option within your playerResponses list. For instance, if you wanted three dialogue response options you would seperate each with a comma, as shown `new string[] {"I'm here to talk to you, you seem pretty cool.", "I was just curious how they allowed you in here.", "Hey here is the third dialogue response"},` and assign the new button as ResponseButton 3 in your inspector window of the DialogueController Game Object. 

**Q: Can I customize the affection point display?**
A: Yes, you can modify the affection point display by changing it to a meter, different text color, whichever you prefer. By default, affection points are set to 0 then dynamically updated through the affectionManager observer. 

**Q: What is BC Mode?**
A: BC mode was implemented for players who struggle in the dating scene. Affection points can never go below 0, and the player will always win in BC mode. 

**Q: Can I update the sprites?**
A: Yes, you can update the sprites to your own character. To do so, you can click on the element you want to update in the hierarchy, and drag and drop your new sprite into the `Sprite` tab in the `Sprite Renderer`.

