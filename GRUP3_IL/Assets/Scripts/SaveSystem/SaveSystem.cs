using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("CurrentStage"))
        {
            Debug.Log("Save File Found");
        }
        else
        {
            Debug.Log("No Save File Found");
            PlayerPrefs.SetInt("CurrentStage", 1);
            PlayerPrefs.SetInt("CollectedPhotos", 0);
            Debug.Log("Current Stage : " + PlayerPrefs.GetInt("CurrentStage"));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && PlayerPrefs.HasKey("CurrentStage"))
        {
            PlayerPrefs.DeleteKey("CollectedPhotos");
            PlayerPrefs.DeleteKey("CurrentStage");

            Debug.Log("Save File Terhapus, Restart Game");
        }
    }

    public int LoadCurrentStage()
    {
        return PlayerPrefs.GetInt("CurrentStage");
    }

    public int LoadCollectedPhotos()
    {
        return PlayerPrefs.GetInt("CollectedPhotos");
    }
}
