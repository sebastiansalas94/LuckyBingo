using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector] public static DialogueManager Instance { get; private set; }
    [HideInInspector] public bool dialogueIsPlaying { get; private set; }
    [HideInInspector] public bool canContinueToNextLine = false;

    [Header("UI Objects")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Display Line Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    private Story currentStory;
    private Coroutine displayLineCoroutine;

    private int openedFrame;


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
        if (canContinueToNextLine  && InputManager.Instance.GetInteractPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        openedFrame = Time.frameCount;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            //HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        //continueIcon.SetActive(false);
        canContinueToNextLine = false;

        dialogueText.ForceMeshUpdate();
        int totalVisibleChars = dialogueText.textInfo.characterCount;

        int visibleCount = 0;
        while (visibleCount <= totalVisibleChars)
        {
            if (Time.frameCount > openedFrame
                && InputManager.Instance.GetInteractPressed())
            {
                dialogueText.maxVisibleCharacters = totalVisibleChars;
                break;
            }

            dialogueText.maxVisibleCharacters = visibleCount;
            visibleCount++;
            yield return new WaitForSeconds(typingSpeed);
        }

        dialogueText.maxVisibleCharacters = totalVisibleChars;
        //continueIcon.SetActive(true);
        canContinueToNextLine = true;
    }
}
