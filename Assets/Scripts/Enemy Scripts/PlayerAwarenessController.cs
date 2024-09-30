using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerAwarenessController is a script that allows the AI to become idle and wander around
 * if it can't detect the player.
 */ 
public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;
    public Behaviour wanderSetter;
    public Behaviour destinationSetter;

    private void Awake()
    {
        /*A way to find the player based on an object it has. 
        In this case, the player has an object called "PlayerMovement" (a script)*/
        _player = FindObjectOfType<PlayerMovement>().transform;
    }
    
    void Update()
    {
        /*Tries to get the distance between itself, and the player.
         This allows it to know when to wake up or when to stay idle*/
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            /*If the enemy does notice the player, it's AI will activate
             and pathfind its way to the player*/

            //AIPath.enabled = true;
            wanderSetter.enabled = false;
            destinationSetter.enabled = true;
            AwareOfPlayer = true;
        }
        else
        {
            /*The AI will turn off if it does not see anyone close*/
            //AIPath.enabled = false;
            wanderSetter.enabled = true;
            destinationSetter.enabled = false;
            AwareOfPlayer = false;
        }
    }
}