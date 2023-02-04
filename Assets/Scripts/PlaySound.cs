using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySounds : MonoBehaviour
{
    public AudioSource audioSource;
    public Button button;
    
    private void Start()
    {
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}
