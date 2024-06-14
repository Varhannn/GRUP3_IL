using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] SaveSystem SaveSystem;

    public void NewGame()
    {
        SaveSystem.NewGame();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 4));
    }

    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("CurrentStage") > 1)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + SaveSystem.LoadCurrentStage()));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
