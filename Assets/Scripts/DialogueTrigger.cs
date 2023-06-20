using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public string[] lines;
    private TextMeshPro dialogueText;
    private GameObject player;
    private bool dialogueOngoing = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");

        dialogueText = gameObject.transform.Find("DialogueText").GetComponent<TextMeshPro>();
        dialogueText.text = string.Empty;
    }

    // Update is called once per frame
    void Update() {
        if (!dialogueOngoing && Input.GetKeyDown(KeyCode.E)) {
            if (Vector3.Distance(transform.position, player.transform.position) < 5) {
                dialogueOngoing = true;
                TriggerDialogue();
            }
        }

        if (dialogueOngoing && Vector3.Distance(transform.position, player.transform.position) > 7.5) {
            dialogueOngoing = false;
            StopDialogue();
        }
    }

    void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(lines, dialogueText);
    }

    void StopDialogue() {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
