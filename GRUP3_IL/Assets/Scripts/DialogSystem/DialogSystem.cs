using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogBox;
    public string[] lines;
    public string[] characterName;
    public float textSpeed;
    private bool canNextLine;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canNextLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                canNextLine = true;
                textComponent.text = characterName[index] + "\n" + lines[index];

            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        canNextLine = false;
        textComponent.text += characterName[index] + "\n";
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
        else
        {
            gameObject.SetActive(false);
            dialogBox.SetActive(false);
        }
    }
}