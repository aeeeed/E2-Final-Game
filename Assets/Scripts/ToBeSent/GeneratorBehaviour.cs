using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    [SerializeField] DoorAnimated doorBehaviour;

    private GameObject e;
    private AudioSource audioSource;
    public AudioClip genStart;

    private bool hasPlayedSound = false;        //to check if door open audio has been played or not
    private bool hasTurnedOn = false;       //check if the generator has been turned on by player

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = genStart;

        e = transform.GetChild(0).gameObject;       //find Indicator (child gameObject)
        e.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        e.SetActive(true);

        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !hasPlayedSound)     //&& !hasPlayedSound makes sure that audio is only played once
            {
                if (hasTurnedOn == false)
                {
                    PlayGenStartAudio();
                    hasPlayedSound = true;
                    doorBehaviour.DoorLockedStatus();
                    hasTurnedOn = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e.SetActive(false);
        hasPlayedSound = false;
    }

    private void PlayGenStartAudio()
    {
        if (genStart != null)
        {
            audioSource.PlayOneShot(genStart);
        }
    }
}
