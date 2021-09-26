using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip coinDrop, doubleSwitch, paperRustle, dropOnWood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseAudioToPlay(int audioType)
    {
        // 1 is coinDrop, 2 is doubleSwitch, 3 is paperRustle and 4 is dropOnWood
        audioSource.Stop();
        audioSource.clip = audioType switch
        {
            1 => coinDrop,
            2 => doubleSwitch,
            3 => paperRustle,
            4 => dropOnWood,
            _ => audioSource.clip
        };
        audioSource.Play();
    }
}
