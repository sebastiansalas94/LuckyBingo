using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJson;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;


    private void Awake()
    {

    }

    private void Update()
    {

    }

    public void StartDialogue()
    {
        DialogueManager.Instance.currentTrigger = this;
        DialogueManager.Instance.EnterDialogueMode(inkJson);
    }
}
