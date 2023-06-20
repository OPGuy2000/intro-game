using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string[] lines;
    public string speakerName;

    // Update is called once per frame
    void OnMouseDown()
    {
        TriggerDialogue();
    }

    void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(lines, speakerName);
    }
}
