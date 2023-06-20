using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    private TextMeshPro dialogueText;

    private string[] lines;
    private int index;
    private bool dialogueOngoing = false;

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

    public void StartDialogue(string[] lineArr, TextMeshPro text) {
        dialogueText = text;
        dialogueOngoing = true;

        lines = lineArr;
        index = 0;
        
        StartCoroutine(TypeLine());

    }

    public void EndDialogue() {
        dialogueOngoing = false;
        dialogueText.text = string.Empty;
        StopAllCoroutines();
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