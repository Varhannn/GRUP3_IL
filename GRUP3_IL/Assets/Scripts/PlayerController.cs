using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using DG.Tweening;

//using dotween
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float hAxis;
    Vector2 direction;

    [SerializeField] float speed = 3;
    [SerializeField] float jumpHeight = 5;

    Rigidbody2D rb;

    [SerializeField] bool onGround = false;

    Animator anim;

    bool isPushing = false;

    [SerializeField] PhotoFragmentsManager photoFragmentsManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Facing();
        Jump();
        Animation();
    }

    void Movement()
    {
        // Apply Movement (Horizontal)
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.velocity = new Vector2(0, 1) * jumpHeight;
        }
    }

    void Facing()
    {
        // If player is moving left scale = -1
        if (hAxis < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }

        // if player is moving right scale = 1
        if (hAxis > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    void Animation()
    {
        // If player moving = running animation
        anim.SetFloat("Moving", Mathf.Abs(hAxis));
        anim.SetBool("OnGround", onGround);
        anim.SetBool("Push", isPushing);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            onGround = true;
            Debug.Log("Ground");
        }

        if (other.CompareTag("Box"))
        {
            isPushing = true;
            Debug.Log("Pushing Box");
        }

        if (other.tag == "PhotoFragments")
        {
            photoFragmentsManager.Add();
            Destroy(other.gameObject);
            Debug.Log("Photo Collected " + photoFragmentsManager.currentPhotoFragments);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            onGround = false;
            Debug.Log("Not Ground");
        }

        if (other.CompareTag("Box"))
        {
            isPushing = false;
            Debug.Log("Not Pushing Box");
        }
    }
}
