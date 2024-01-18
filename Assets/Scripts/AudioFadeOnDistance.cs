using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOnDistance : MonoBehaviour
{
    public Transform playerTransform; // The player's transform
    public float maxDistance = 10f; // Maximum distance for full volume
    public float minDistance = 2f; // Minimum distance for minimum volume
    public float fadeSpeed = 1f; // Speed at which the volume fades

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }

        // If playerTransform is not assigned, try to find the player by tag
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogWarning("PlayerTransform not assigned, and no GameObject with the 'Player' tag found.");
            }
        }
    }

    void Update()
    {
        if (audioSource != null && playerTransform != null)
        {
            // Calculate the distance between the player and the audio source in 2D space
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                                              new Vector2(playerTransform.position.x, playerTransform.position.y));

            // Calculate the desired volume based on the distance
            float targetVolume = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(minDistance, maxDistance, distance));

            // Smoothly adjust the volume towards the target volume
            audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, fadeSpeed * Time.deltaTime);
        }
    }
}
