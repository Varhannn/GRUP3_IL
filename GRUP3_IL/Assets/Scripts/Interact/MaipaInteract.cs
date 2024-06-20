using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaipaInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision collision)
    {
        Debug.Log("Interact");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Interact");
        }
    }
}
