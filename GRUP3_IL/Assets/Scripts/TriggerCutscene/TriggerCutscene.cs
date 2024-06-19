using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject cutsceneCanvas;
    public PlayableDirector playableDirector;
    public PhotoFragmentsManager photoFragmentsManager;
    [SerializeField] bool isTrigger = false;


    void Start()
    {
        cutsceneCanvas.SetActive(false);
    }
    void Update()
    {
        if (photoFragmentsManager.currentPhotoFragments == 1 && !isTrigger)
        {
            player.SetActive(false);
            isTrigger = true;
            cutsceneCanvas.SetActive(true);
        }

        if (playableDirector.state == PlayState.Paused)
        {
            player.SetActive(true);
            cutsceneCanvas.SetActive(false);
        }
    }
}
