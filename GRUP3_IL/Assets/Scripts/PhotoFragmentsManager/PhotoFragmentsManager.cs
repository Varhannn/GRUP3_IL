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
        currentPhotoFragments++;
    }

    void Update()
    {
        text.text = "Collected Photo : " + currentPhotoFragments + " / " + photoFragmentsTotal.ToString();
    }
}
