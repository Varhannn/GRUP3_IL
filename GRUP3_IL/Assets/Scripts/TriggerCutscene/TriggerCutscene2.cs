using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutscene2 : MonoBehaviour
{
    public PhotoFragmentsManager photoFragmentsManager;
    public PlayableDirector playableDirector;
    public GameObject cutsceneCanvas;
    public GameObject player;
    private bool isTrigger = false;

    void Update()
    {

        if (photoFragmentsManager.currentPhotoFragments == 6 && !isTrigger)
        {
            cutsceneCanvas.SetActive(true);
            playableDirector.Play();
            isTrigger = true;
            player.SetActive(false);
        }

        if (playableDirector.state == PlayState.Paused)
        {
            player.SetActive(true);
            cutsceneCanvas.SetActive(false);
        }
    }
}
