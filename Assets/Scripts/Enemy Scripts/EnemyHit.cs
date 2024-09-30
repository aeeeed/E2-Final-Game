using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public AIPath aiPath;
    public HealthManager hM;
    public float damage;

    [SerializeField] private AudioSource roarSound;
    [SerializeField] private AudioSource growlSound;

    private bool isPlayerHit = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isPlayerHit == false && collider.gameObject == GameObject.Find("Player"))
        {
            hM.TakeDamage(damage);
            aiPath.canMove = false;
            growlSound.Stop();
            roarSound.Play();
            isPlayerHit = true;
            StartCoroutine(delay());
            
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        isPlayerHit = false;
        aiPath.canMove = true;
    }
}
