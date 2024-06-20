using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonologEnding : MonoBehaviour
{
    public PhotoFragmentsManager photoFragmentsManager;
    public GameObject monologEnding;
    bool isTrigger;
    void Update()
    {
        if (photoFragmentsManager.currentPhotoFragments == 9 && !isTrigger)
        {
            isTrigger = true;
            monologEnding.SetActive(true);
        }
    }
}
