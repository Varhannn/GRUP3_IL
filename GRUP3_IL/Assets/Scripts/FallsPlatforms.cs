using System.Collections;
using UnityEngine;

public class FallsPlatforms : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool OnPlatform = false;
    private Animator anim;
    private Vector3 originalPosition;

    public float fallDelay = 1f;
    public float respawnDelay = 5f;
    public GameObject platformPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        anim = GetComponent<Animator>();
        originalPosition = transform.position;
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
        yield return new WaitForSeconds(respawnDelay - delay);
        RespawnPlatform();
    }

    private void RespawnPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        transform.position = originalPosition;
        OnPlatform = false;
        anim.SetTrigger("Idle");
    }
}
