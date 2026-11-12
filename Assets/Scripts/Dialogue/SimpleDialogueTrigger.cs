using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleDialogueTrigger : MonoBehaviour
{
    //Both method works, it depends if you want to handle a single one or multiple ones.

    [Header("Single Ink File")]
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
