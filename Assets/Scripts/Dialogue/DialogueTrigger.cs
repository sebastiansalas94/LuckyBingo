using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJson;


    private void Awake()
    {

    }

    private void Update()
    {

    }

    public void StartDialogue()
    {
        DialogueManager.Instance.EnterDialogueMode(inkJson);
    }
}
