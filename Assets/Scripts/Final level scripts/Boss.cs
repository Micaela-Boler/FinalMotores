using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : Enemy
{
    [Header("BOSS")]
    [SerializeField] Collider2D shieldCollider;
    [SerializeField] float actionCooldown;
    [SerializeField] float shieldDuration;
    private bool right;

    

    private void Start()
    {
        shieldCollider.enabled = false;
    }


    protected override void EnemyPatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        animator.SetBool("isRunning", true);
        LookAtPlayer();
    }

    protected override IEnumerator EnemyAttack(Collider2D usingAttackCollider, float attackTime, float attackCooldown, string animationName)
    {
        animator.SetBool("isRunning", false);
        transform.position = transform.position;

        yield return new WaitForSeconds(actionCooldown);
        
        StartCoroutine(Shield()); 
    }
    


    IEnumerator Shield()
    {
        canAttack = false;
        shieldCollider.enabled = true;
        animator.SetTrigger("usingShield");
        gameObject.GetComponent<EnemyHealth>().canTakeDamage = false;

        yield return new WaitForSeconds(shieldDuration);

        canAttack = true;
        shieldCollider.enabled = false;
        animator.SetTrigger("Waiting");
        gameObject.GetComponent<EnemyHealth>().canTakeDamage = true;
    }


    private void LookAtPlayer()
    {
        if (player.position.x > transform.position.x && !right || player.position.x < transform.position.x && right) 
        {
            right = !right;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}
