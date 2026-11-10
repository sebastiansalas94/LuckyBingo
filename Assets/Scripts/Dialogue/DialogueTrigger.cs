using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    //Both method works, it depends if you want to handle a single one or multiple ones.

    [Header("Single Ink File")]
    public TextAsset inkJson;

    [Header("Multiple Ink Files")]
    [SerializeField] private TextAsset inkJsonSequence1;
    [SerializeField] private TextAsset inkJsonSequence2;
    [SerializeField] private TextAsset inkJsonSequence3;
    [SerializeField] private TextAsset inkJsonSequence4;
    [SerializeField] private TextAsset inkJsonSequence5;


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

    public void StartDialogue(TextAsset newInkJson)
    {
        DialogueManager.Instance.EnterDialogueMode(newInkJson);
    }

    public void StartDialogue(int sequenceNumber)
    {
        switch (sequenceNumber)
        {
            case 0:
                AudioManager.Instance.GetComponent<AudioManager>().PlayRandomClipBingoBall();
                DialogueManager.Instance.EnterDialogueMode(inkJsonSequence1);
                break;
            case 1:
                AudioManager.Instance.GetComponent<AudioManager>().PlayRandomClipBingoBall();
                DialogueManager.Instance.EnterDialogueMode(inkJsonSequence2);
                break;
            case 2:
                AudioManager.Instance.GetComponent<AudioManager>().PlayRandomClipBingoBall();
                DialogueManager.Instance.EnterDialogueMode(inkJsonSequence3);
                break;
            case 3:
                AudioManager.Instance.GetComponent<AudioManager>().PlayClipBingoBallSick();
                DialogueManager.Instance.EnterDialogueMode(inkJsonSequence4);
                break;
            case 4:
                AudioManager.Instance.GetComponent<AudioManager>().PlayClipBingoBallSick();
                DialogueManager.Instance.EnterDialogueMode(inkJsonSequence5);
                break;
            default:
                Debug.LogWarning("SequenceNumber came in but is not currently being handled: " + sequenceNumber);
                break;
        }
    }
}
