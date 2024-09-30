using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private GameObject[] zombies;

    [SerializeField]
    private GameObject stalker;

    private GameObject ambience;
    private void Awake()
    {
        zombies = GameObject.FindGameObjectsWithTag("Enemy");
        //stalker = GameObject.FindGameObjectWithTag("EnemyBoss");
        ambience = GameObject.FindGameObjectWithTag("Ambience");

        foreach (GameObject zom in zombies)
        {
            zom.GetComponent<Animator>().SetBool("IsRisen", false);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        StartCoroutine(wakeUp());

    }
    IEnumerator wakeUp()
    {
        yield return new WaitForSeconds(1);


        ambience.GetComponent<AudioSource>().enabled = true;

        foreach (GameObject zom in zombies)
        {
            zom.GetComponent<Animator>().SetBool("IsRisen", true);
            Debug.Log("Anm, On");
            zom.GetComponent<PlayerAwarenessController>().enabled = true;
            Debug.Log("PAC, On");
            zom.GetComponent<WanderingDestinationSetter>().enabled = true;
            Debug.Log("WDS, On");
            zom.GetComponent<CapsuleCollider2D>().enabled = true;
            Debug.Log("Col, On");
        }

        stalker.SetActive(true);
        

    }
}
