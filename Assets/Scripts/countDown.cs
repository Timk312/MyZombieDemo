using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public TMP_Text countdownText;
    public float countdownDuration = 20f;
    public GameObject textObject;

    private void Start()
    {
        // Start the countdown when the script is initialized
        StartCoroutine(StartCountdown());
    }

    public void startCountdown()
    {
        StartCoroutine(StartCountdown());
    }
    private IEnumerator StartCountdown()
    {
        float countdownValue = countdownDuration;

        while (countdownValue > 0)
        {
            // Update the UI text with the current countdown value
            countdownText.text = Mathf.CeilToInt(countdownValue).ToString();

            // Wait for a short duration before decreasing the countdown
            yield return new WaitForSeconds(1f);

            // Decrease the countdown value
            countdownValue--;
        }
        textObject.SetActive(false);
    }
}
