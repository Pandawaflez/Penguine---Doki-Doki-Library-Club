using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIOverlay : UIElement
{
    private Dictionary<string, Slider> characterMeters; // Store sliders for each character
    private Dictionary<string, Text> characterTexts;    // Store text fields for each character

    public UIOverlay(GameObject overlayPanel, Sprite[] characterImages, string[] characterNames)
        : base(overlayPanel) // Initialize the base class with the overlay panel
    {
        characterMeters = new Dictionary<string, Slider>();
        characterTexts = new Dictionary<string, Text>();

        CreateCharacterUI(characterImages, characterNames);
    }

    // Create the UI elements for all characters
    private void CreateCharacterUI(Sprite[] images, string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            GameObject container = new GameObject(names[i], typeof(RectTransform));
            container.transform.SetParent(GetComponent<RectTransform>());

            RectTransform rect = container.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(500, 60); // Adjust size of each character row
            rect.anchoredPosition = new Vector2(0, 200 - (i * 70)); // Space out the rows

            // Create the profile image
            Image profileImage = CreateProfileImage(images[i], container);

            // Create the progress meter (Slider)
            Slider progressMeter = CreateProgressMeter(container);

            // Create the points text field
            Text pointsText = CreatePointsText(container);

            // Store the slider and text for later updates
            characterMeters[names[i]] = progressMeter;
            characterTexts[names[i]] = pointsText;
        }
    }

    // Helper: Create the profile image
    private Image CreateProfileImage(Sprite image, GameObject parent)
    {
        GameObject imageObject = new GameObject("ProfileImage", typeof(Image));
        imageObject.transform.SetParent(parent.transform);

        Image img = imageObject.GetComponent<Image>();
        img.sprite = image;

        RectTransform rect = imageObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(50, 50);
        rect.anchoredPosition = new Vector2(-200, 0); // Align on the left

        return img;
    }

    // Helper: Create the progress meter (Slider)
    private Slider CreateProgressMeter(GameObject parent)
    {
        GameObject sliderObject = new GameObject("ProgressMeter", typeof(Slider));
        sliderObject.transform.SetParent(parent.transform);

        Slider slider = sliderObject.GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 100; // Assume 100 is the max points value
        slider.value = 0; // Start at 0

        RectTransform rect = slider.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 20);
        rect.anchoredPosition = new Vector2(50, 0); // Align in the center

        return slider;
    }

    // Helper: Create the points text field
    private Text CreatePointsText(GameObject parent)
    {
        GameObject textObject = new GameObject("PointsText", typeof(Text));
        textObject.transform.SetParent(parent.transform);

        Text pointsText = textObject.GetComponent<Text>();
        pointsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        pointsText.fontSize = 18;
        pointsText.color = Color.white;
        pointsText.text = "0 points"; // Initial value

        RectTransform rect = pointsText.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 30);
        rect.anchoredPosition = new Vector2(180, 0); // Align to the right

        return pointsText;
    }

    // Update the character's meter and points display
    public void UpdateCharacterUI(string name, int points)
    {
        if (characterMeters.ContainsKey(name))
        {
            characterMeters[name].value = points;
            characterTexts[name].text = $"{points} points";
        }
    }
}
