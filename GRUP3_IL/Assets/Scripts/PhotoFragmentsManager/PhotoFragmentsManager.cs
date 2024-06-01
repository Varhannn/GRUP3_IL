using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotoFragmentsManager : MonoBehaviour
{
    [SerializeField] int photoFragmentsTotal = 9;
    [SerializeField] TextMeshProUGUI text;
    public int currentPhotoFragments = 0;

    public void Add()
    {
        currentPhotoFragments += 1;
    }

    void Update()
    {
        text.text = ": " + currentPhotoFragments + " / " + photoFragmentsTotal.ToString();
    }
}
