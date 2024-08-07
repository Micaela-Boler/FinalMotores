using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [Header("PLAYER")]
    [SerializeField] float immunityDuration;
    public HealthBar healthBar;
    public GameManager manager;


    [Header("SCREEN")]
    [SerializeField] GameObject screen;



    private void Start()
    {
        healthBar.StartHealth(5);
        screen.SetActive(false);
        canTakeDamage = true;
    }

    protected override void TakeDamage()
    {
        characterCanMove = gameObject.GetComponent<MovePlayer>().canMove;

        base.TakeDamage();
        StartCoroutine(Immunity());
        healthBar.ChangeActualHealth(health);

        if (health <= 0)
            StartCoroutine(waitForPanel());
    }


    private IEnumerator waitForPanel()
    {
        gameObject.GetComponent<MovePlayer>().canMove = false;
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2);

        manager.panelManager(screen);
    }


    IEnumerator Immunity()
    {
        canTakeDamage = false;

        yield return new WaitForSeconds(immunityDuration);

        canTakeDamage = true;
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(collisionGameObject) && canTakeDamage)
        {
            TakeDamage();
        }
    }
}
