using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private bool isMoving = false;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.linearVelocity;

        if (velocity.magnitude > 0.1f || velocity.magnitude < -0.1f) {
            isMoving = true;
        }
        else { 
            isMoving = false;
        }

        if (isMoving) {
            animator.SetFloat("X", velocity.x);
            animator.SetFloat("Y", velocity.y);
        }

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isAttacking", isAttacking);
    }

    public void SetIsAttacking()
    {
        if (!isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(.8f);
        isAttacking = false;
    }
}
