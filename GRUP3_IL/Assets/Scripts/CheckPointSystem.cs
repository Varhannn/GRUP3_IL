using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    public Transform currentCheckpoint;

    public void setCheckPoint(Transform _checkpoint)
    {
        currentCheckpoint = _checkpoint;
    }
}
