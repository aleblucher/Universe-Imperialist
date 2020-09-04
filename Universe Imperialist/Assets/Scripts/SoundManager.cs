using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip playerAttack;
    public GameObject soundGameObject;

    public void Awake()
    {
        soundGameObject = new GameObject("Sound");
    }
    

    public void PlaySound()
    {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(playerAttack);

    }

}
