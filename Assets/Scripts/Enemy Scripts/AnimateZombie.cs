using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateZombie : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
    }
}
