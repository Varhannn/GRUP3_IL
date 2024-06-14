using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();

        if (PlayerPrefs.GetInt("CurrentStage") > 1)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }

}
