using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public Button playButton;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() => ChangeScene(sceneName));
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
