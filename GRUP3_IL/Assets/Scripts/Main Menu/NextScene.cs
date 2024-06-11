using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string sceneName;
    [SerializeField] PhotoFragmentsManager photoFragmentsManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("CurrentStage", SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Current Stage Saved : " + PlayerPrefs.GetInt("CurrentStage"));
        PlayerPrefs.SetInt("CollectedPhotos", photoFragmentsManager.currentPhotoFragments);

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
    private IEnumerator ChangeScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
