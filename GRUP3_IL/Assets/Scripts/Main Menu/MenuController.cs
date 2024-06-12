using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public Button playButton;
    [SerializeField] SaveSystem SaveSystem;

    // Update is called once per frame
    void Start()
    {
        playButton.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        if (PlayerPrefs.HasKey("CurrentStage") && PlayerPrefs.GetInt("CurrentStage") == 1)
        {
            SceneManager.LoadScene("PrologCutscene");
        }
        else
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
