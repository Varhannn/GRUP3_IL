using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float yPosition = transform.localPosition.y;
        transform.DOLocalMoveY(yPosition + 0.4f, 0.6f).SetLoops(-1, LoopType.Yoyo);
    }

    void OnDestroy()
    {
        transform.DOKill();
    }

}
