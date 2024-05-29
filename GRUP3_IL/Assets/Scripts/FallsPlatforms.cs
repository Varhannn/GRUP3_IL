using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallsPlatforms : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool OnPlatform = false;
    private Animator anim;

    public float fallDelay = 1f;
    public float destroyDelay = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !OnPlatform)
        {
            OnPlatform = true;
            StartCoroutine(FallAfterDelay(fallDelay));
        }
    }

    private IEnumerator FallAfterDelay(float delay)
    {
        anim.SetTrigger("Vibrate");
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;  
        rb.gravityScale = 1;
        StartCoroutine(DestroyAfterDelay(destroyDelay));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
