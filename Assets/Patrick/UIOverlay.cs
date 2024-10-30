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
            // Debug.Log("Creating progress meter");



        // Create the slider object and attach it to the parent
        GameObject sliderObject = new GameObject("ProgressMeter", typeof(Slider));
        sliderObject.transform.SetParent(parent.transform, false);

        // Configure the Slider component
        Slider slider = sliderObject.GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 100;      //max points
        slider.value = 0;

        // Set up the RectTransform for proper alignment
        RectTransform rect = slider.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(250, 20);  // Set the desired size
        rect.anchorMin = new Vector2(0, 0.5f);  // Anchor to the middle-left
        rect.anchorMax = new Vector2(0, 0.5f);  // Same for both min and max for left alignment
        rect.pivot = new Vector2(0, 0.5f);      // Set pivot to the left-center
        rect.anchoredPosition = new Vector2(100, 0);

        // Create the background image for the slider
        GameObject background = new GameObject("Background", typeof(Image));
        background.transform.SetParent(sliderObject.transform, false);
        Image bgImage = background.GetComponent<Image>();
        bgImage.color = new Color(0.5f, 0, 0.5f, 0.7f);  // Light gray background

        RectTransform bgRect = background.GetComponent<RectTransform>();
        bgRect.anchorMin = Vector2.zero;
        bgRect.anchorMax = Vector2.one;
        bgRect.offsetMin = Vector2.zero;  // No padding inside the background
        bgRect.offsetMax = Vector2.zero;  // No padding inside the background

        // Create the fill area for the slider
        GameObject fillArea = new GameObject("FillArea", typeof(Image));
        fillArea.transform.SetParent(sliderObject.transform, false);
        Image fillImage = fillArea.GetComponent<Image>();
        fillImage.color = Color.red;  // Green fill for the progress

        RectTransform fillRect = fillArea.GetComponent<RectTransform>();
        fillRect.anchorMin = Vector2.zero;  // Anchor the fill to the left
        fillRect.anchorMax = Vector2.one;   // Stretch the fill horizontally
        fillRect.offsetMin = new Vector2(0, 2);  // Optional: Add slight padding inside
        fillRect.offsetMax = new Vector2(0, -2); // Optional: Adjust for better alignment

        // Assign the fill area to the slider's fillRect property
        slider.fillRect = fillRect;

        // Optional: Create a handle for better visualization
        GameObject handle = new GameObject("Handle", typeof(Image));
        handle.transform.SetParent(sliderObject.transform, false);
        Image handleImage = handle.GetComponent<Image>();
        handleImage.color = Color.white;  // White handle for visibility

        RectTransform handleRect = handle.GetComponent<RectTransform>();
        handleRect.sizeDelta = new Vector2(10, 20);  // Adjust the size of the handle
        slider.handleRect = handleRect;  // Assign the handle to the slider

        return slider;
    }

    // Helper: Create the points text field
    private Text CreatePointsText(GameObject parent)
    {
        GameObject textObject = new GameObject("PointsText", typeof(Text));
        textObject.transform.SetParent(parent.transform);

        Text pointsText = textObject.GetComponent<Text>();
        pointsText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
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

    // Helper: Create the fill area for the Slider
    private GameObject CreateFillArea(GameObject sliderObject)
    {
        GameObject fillArea = new GameObject("FillArea", typeof(RectTransform), typeof(Image));
        fillArea.transform.SetParent(sliderObject.transform);

        RectTransform fillRect = fillArea.GetComponent<RectTransform>();
        fillRect.anchorMin = Vector2.zero;
        fillRect.anchorMax = Vector2.one;
        fillRect.sizeDelta = Vector2.zero;  // Fill should fit the slider size

        Image fillImage = fillArea.GetComponent<Image>();
        fillImage.color = Color.green;  // Example fill color for visualization

        return fillArea;
    }
}
