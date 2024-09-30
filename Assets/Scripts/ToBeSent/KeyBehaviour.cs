using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] DoorAnimated doorBehaviour;

    private GameObject e;
    //private AudioSource audioSource;
    public AudioClip keyPickUp;

    private bool hasPlayedSound = false;        //to check if door open audio has been played or not

    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();

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
                PlayKeyPickUpAudio();
                hasPlayedSound = true;
                doorBehaviour.DoorLockedStatus();
                Destroy(gameObject);
                //e.SetActive(false);
                //gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e.SetActive(false);
        hasPlayedSound = false;
    }

    private void PlayKeyPickUpAudio()
    {
        if (keyPickUp != null)
        {
            //audioSource.PlayOneShot(keyPickUp);

            //this will create a temporary gameObject to play the audio, this took me awhile.....
            GameObject audioGameObject = new GameObject("KeyAudio");
            AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();
            audioSource.clip = keyPickUp;
            audioSource.Play();

            //destroys the temporary GameObject after the audio clip has finished playing
            Destroy(audioGameObject, keyPickUp.length);
        }
    }
}
