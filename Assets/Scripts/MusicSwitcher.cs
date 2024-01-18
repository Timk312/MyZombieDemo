using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public List<AudioClip> musicTracks = new List<AudioClip>();
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }

        // Play the first music track on start
        SwitchMusic(0);
    }

    void Update()
    {
        // Example: Switch music tracks with a key press (you can customize this based on your game's input system)
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Switch to the next music track
            SwitchMusic((currentTrackIndex + 1) % musicTracks.Count);
        }
    }

    void SwitchMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= musicTracks.Count)
        {
            Debug.LogWarning("Invalid music track index.");
            return;
        }

        // Stop the current music track
        audioSource.Stop();

        // Switch to the new music track
        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();

        // Update the current track index
        currentTrackIndex = trackIndex;
    }
}