using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public Canvas canvas;
    private TextMeshProUGUI dialogueText;
    private TextMeshProUGUI nameText;

    private string[] lines;
    private int index;
    private bool dialogueOngoing = false;

    // Start is called before the first frame update
    void Start()
    {
        nameText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        dialogueText = canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        dialogueText.text = string.Empty;
        nameText.text = string.Empty;
    }

    void Update() {
        if (dialogueOngoing && Input.GetMouseButtonDown(0)) {
            if (dialogueText.text != lines[index]) {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            } else {
                NextLine();
            }
        }
    }

    public void StartDialogue(string[] lineArr, string name) {
        canvas.gameObject.SetActive(true);
        dialogueOngoing = true;

        lines = lineArr;
        index = 0;
        nameText.text = name;
        
        StartCoroutine(TypeLine());
    }

    public void EndDialogue() {
        dialogueOngoing = false;
        StopAllCoroutines();
        canvas.gameObject.SetActive(false);
    }

    void NextLine() {
        dialogueText.text = string.Empty;
        index++;
        if (index < lines.Length) {
            StartCoroutine(TypeLine());
        } else {
            EndDialogue();
        }
    }

    IEnumerator TypeLine() {
        foreach(char c in lines[index].ToCharArray()) {
            dialogueText.text += c;
            yield return null;
        }
    }
}