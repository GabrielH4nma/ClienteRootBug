using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySounds : MonoBehaviour
{
    public AudioSource audioSource;
    public Button button;
    public AudioClip[] musicClips;

    private void Start()
    {
        button.onClick.AddListener(PlayMusic);
        audioSource.playOnAwake = false;
    }

    private void PlayMusic()
    {
        int randomIndex = Random.Range(0, musicClips.Length);
        audioSource.clip = musicClips[randomIndex];
        audioSource.Play();
    }
}
