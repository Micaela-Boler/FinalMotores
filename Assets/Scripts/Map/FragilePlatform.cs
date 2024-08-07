using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float timeToFall;
    [SerializeField] float timeToDestroy;
    [SerializeField] AudioSource audioSource;
    [SerializeField] string collisionGameObjectName;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }



    IEnumerator gravity()
    {
        animator.SetTrigger("Warning");
        audioSource.Play();

        yield return new WaitForSeconds(timeToFall);

        rb.gravityScale = 1;
    }


    IEnumerator destroyingPlatform()
    {
        yield return new WaitForSeconds(3);

        animator.SetTrigger("timeToDestroy");
        Destroy(gameObject, timeToDestroy);
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        collisionGameObjectName = collision.gameObject.tag;

        switch (collisionGameObjectName)
        {
            case "Player": StartCoroutine(gravity());
                break;

            case "DeathZone": StartCoroutine(destroyingPlatform());
                break;
        }
    }
}
