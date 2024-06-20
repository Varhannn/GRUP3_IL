using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaipaInteract : MonoBehaviour
{

    public GameObject dialogSystem;

    public MonoBehaviour playerMovementScript;
    public MonoBehaviour dialogueScript;
    private bool InRange;


    private void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogSystem != null)
            {
                dialogueScript.enabled = true;
                bool dialogActive = !dialogSystem.activeSelf;
                dialogSystem.SetActive(dialogActive);

                playerMovementScript.enabled = !dialogActive;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            if (dialogSystem != null && dialogSystem.activeSelf)
            {
                dialogSystem.SetActive(false);
                playerMovementScript.enabled = true;
                dialogueScript.enabled = false;
            }
        }
    }
}