using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string sceneName;
    public PlayableDirector playableDirector;
    public GameObject player;
    public GameObject CutsceneCanvas;
    public GameObject timer;
    public bool isEnding;
    [SerializeField] PhotoFragmentsManager photoFragmentsManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("CurrentStage", SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Current Stage Saved : " + PlayerPrefs.GetInt("CurrentStage"));
        PlayerPrefs.SetInt("CollectedPhotos", photoFragmentsManager.currentPhotoFragments);

        if (collision.CompareTag("Player"))
        {
            if (isEnding)
            {
                player.SetActive(false);
                CutsceneCanvas.SetActive(true);
                playableDirector.Play();
                timer.SetActive(true);
                PlayerPrefs.SetInt("CurrentStage", 1);
                PlayerPrefs.SetInt("CollectedPhotos", 0);
            }
            else
            {
                StartCoroutine(ChangeScene());
            }
        }
    }
    private IEnumerator ChangeScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
