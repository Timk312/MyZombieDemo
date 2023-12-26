using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip moveSound; // Assign your audio clip in the Unity Inspector
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the player GameObject.");
        }
    }

    void Update()
    {
        // Check if the player is moving (you may need to customize this based on your player's movement logic)
        // For simplicity, this example assumes that the player is moving if any of the input axes have non-zero values.
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        isMoving = (Mathf.Abs(horizontalMovement) > 0.1f || Mathf.Abs(verticalMovement) > 0.1f);

        // Play or stop the audio based on player movement
        if (isMoving && !audioSource.isPlaying)
        {
            // Player is moving, and the audio is not currently playing, so play it.
            audioSource.clip = moveSound;
            audioSource.Play();
        }
        else if (!isMoving && audioSource.isPlaying)
        {
            // Player is not moving, but the audio is currently playing, so stop it.
            audioSource.Stop();
        }
    }
}