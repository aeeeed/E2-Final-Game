using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider;
    private GameObject e;
    private AudioSource audioSource;
    public AudioClip openSound;

    public bool _isDoorOpen = false;        //to check if door is open or not
    public bool _isDoorLocked = true;       //sets door to locked status
    private bool hasPlayedSound = false;    //to check if door open audio has been played or not

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = openSound;

        e = transform.GetChild(0).gameObject;       //find Indicator (child gameObject)
        e.SetActive(false);
    }

    private void Update()
    {
        if (_isDoorOpen)
        {
            OpenDoor();
        }
        else if (!_isDoorOpen)
            CloseDoor();
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
        collider.enabled = false;
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
        collider.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        e.SetActive(true);
        if (collision.gameObject == GameObject.Find("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !hasPlayedSound)     //&& !hasPlayedSound makes sure that audio is only played once
            {
                if (!_isDoorLocked)
                {
                    PlayOpenSound();
                    _isDoorOpen = true;
                    hasPlayedSound = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e.SetActive(false);
        _isDoorOpen = false;
        hasPlayedSound = false;
    }

    public void DoorLockedStatus()
    {
        _isDoorLocked = !_isDoorLocked;
    }

    private void PlayOpenSound()
    {
        if (openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }
    }
}
