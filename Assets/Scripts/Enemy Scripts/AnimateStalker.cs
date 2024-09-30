using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Custom script to animate the stalker
public class AnimateStalker : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    
    void Update()
    {
        /*
         * The animator has 4 different animations for the Stalker.
         * These animations represent the Stalker walking either up, down, left, right
         * For the animations to play at the right time, we need to get the value of where 
         * the sprite will we going towards.
         * 
         * For this, we need the desiredVelocity of the AIPath. 
         * desiredVelocity is a variable within the AIPath script that will try to move the
         * AI towards a destination. From here, we can get the value and play the right animation.
         * 
         * If the AI is going... 
         * ...up, desiredVelocity.x = < 1. Then play the animation of Stalker going up.
         * ...down, desiredVelocity.x = > 1. Then play the animation of Stalker going down.
         * ...left, desiredVelocity.x = > 1. Then play the animation of Stalker going left.
         * ...right, desiredVelocity.x = > 1. Then play the animation of Stalker going right.
         * 
         * As for the speed, it tells if the animation should play if it goes beyond 0.
        */
        animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        animator.SetFloat("Vertical", aiPath.desiredVelocity.y);
        animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
    }
}
