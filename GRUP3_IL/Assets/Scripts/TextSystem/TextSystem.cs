using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using System.Threading;

public class TextSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public PlayableDirector timeline;
    [SerializeField] bool canClick;
    [SerializeField] int index;
    [SerializeField] float holdTime;




    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        SkipCutscene();

        if (Input.GetMouseButtonDown(0) && canClick)
        {

            if (textComponent.text == lines[index])
            {
                Debug.Log(index + 1);
                if (index == 11)
                {
                    canClick = false;
                    StartCoroutine(PlayTimeline(3f));
                    StartCoroutine(EnableCanClick(3f));

                }
                else if (index == 12)
                {
                    canClick = false;
                    StartCoroutine(PlayTimeline(5.30f));
                    StartCoroutine(EnableCanClick(5.30f));
                }
                else if (index == 21)
                {
                    canClick = false;
                    StartCoroutine(PlayTimeline(5.70f));
                    StartCoroutine(EnableCanClick(5.70f));

                }
                else if (index == 22)
                {
                    canClick = false;
                    StartCoroutine(PlayTimeline(5.70f));
                    StartCoroutine(EnableCanClick(5.70f));
                }
                else if (index == 25)
                {
                    canClick = false;
                    StartCoroutine(PlayTimeline(4.30f));
                    StartCoroutine(EnableCanClick(4.30f));
                }
                else if (index == 26)
                {
                    canClick = false;
                    StartCoroutine(ChangeScene());
                }
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }
    void SkipCutscene()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            holdTime = Time.time;
        }
        else if (Input.GetKey(KeyCode.F))
        {
            if (Time.time - holdTime > 3f)
            {
                holdTime = float.PositiveInfinity;
                SceneManager.LoadScene("Stage1");
            }
        }
        else
        {
            holdTime = float.PositiveInfinity;
        }
        // canClick = false;
        // SceneManager.LoadScene("Stage1");
    }
    IEnumerator EnableCanClick(float duration)
    {
        yield return new WaitForSeconds(duration);
        canClick = true;
    }
    IEnumerator PlayTimeline(float duration)
    {
        timeline.Play();
        yield return new WaitForSeconds(duration);
        timeline.Pause();
    }

    IEnumerator ChangeScene()
    {
        timeline.Resume();
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Stage1");
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}