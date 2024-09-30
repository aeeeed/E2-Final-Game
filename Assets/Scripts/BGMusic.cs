using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    public static BGMusic instance;

    void Awake()
    {
        if (instance != null)       //if same audio GameObject exists, then it destroys to avoid overlapping audio
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Level2")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "GoodEnding")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "BadEnding")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
    }
}
