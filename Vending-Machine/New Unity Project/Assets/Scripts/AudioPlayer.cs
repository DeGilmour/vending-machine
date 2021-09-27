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
        switch (audioType)
        {
            case 1:
                audioSource.priority = 10;
                audioSource.clip = coinDrop;
                break; 
            case 2:
                audioSource.clip = doubleSwitch;
                break;
            case 3:
                audioSource.clip = paperRustle;
                break;
            case 4:
                audioSource.clip = dropOnWood;
                break;
        }
        audioSource.Play();
    }
}
