using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
   

    public float scrollSpeed = 20f; // Adjust this to control the scrolling speed
    public RectTransform creditsText; // Reference to the RectTransform of your Text element

    void Start()
    {
        // Set the initial position of the credits text to the bottom of the screen
        creditsText.anchoredPosition = new Vector2(0, -Screen.height / 2);
      

    }

    void Update()
    {
        // Move the credits text upwards
        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Check if the credits have reached the top of the screen
        if (creditsText.anchoredPosition.y > Screen.height / 2)
        {
            // You may want to trigger some action when the credits finish scrolling, such as loading another scene.
            // For now, you can disable the script or GameObject to stop scrolling.
           // gameObject.SetActive(false);
        }
    }
}
