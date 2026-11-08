using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector] public static DialogueManager Instance { get; private set; }
    [HideInInspector] public bool dialogueIsPlaying { get; private set; }
    [HideInInspector] public DialogueTrigger currentTrigger = null;
    private Story currentStory;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (!dialogueIsPlaying) return;
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        if (currentTrigger.dialoguePanel != null && currentTrigger.dialogueText != null)
        {
            currentStory = new Story(inkJson.text);

            currentTrigger.dialoguePanel.SetActive(true);
            dialogueIsPlaying = true;
            ContinueStory();
        }
    }

    private IEnumerator ExitDialogueMode()
    {
        if (currentTrigger.dialoguePanel != null && currentTrigger.dialogueText != null)
        {
            yield return new WaitForSeconds(0.2f);
            dialogueIsPlaying = false;
            currentTrigger.dialoguePanel.SetActive(false);
            currentTrigger.dialogueText.text = "";
            // hasDialoguePlayed[GameManager.Instance.currentCustomer.charId] = true;
        }
    }

    private void ContinueStory()
    {
        if (currentTrigger.dialoguePanel != null && currentTrigger.dialogueText != null)
        {
            if (currentStory.canContinue)
            {
                currentTrigger.dialogueText.text = currentStory.Continue();
            }
            else
            {
                StartCoroutine(ExitDialogueMode());
            }
        }
    }
}
