using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedOfPlayer = 1;
    public Rigidbody2D rb;
    [SerializeField] private AudioSource footstepSound;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        //transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime * SpeedOfPlayer;
        //rb.velocity = new Vector2(transform.position.x, transform.position.y);

        rb.velocity = new Vector2(moveX, moveY) * SpeedOfPlayer;    /*velocity is how fast rigidbody that is the sprite moves*/
        if (rb.velocity.sqrMagnitude > 0f)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }
    IEnumerator footstepDelay ()
    {
        yield return new WaitForSeconds(1);
        footstepSound.Play();
        yield return new WaitForSeconds(1);
        footstepSound.Stop();
    }
}
