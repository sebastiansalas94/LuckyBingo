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
    private const string SPEAKER_TAG = "SPEAKER";
    private const string AUDIO_TAG = "AUDIO";
    private const string KNOCK_DOOR_TAG = "KNOCK_DOOR";

    [HideInInspector] public static DialogueManager Instance { get; private set; }
    [HideInInspector] public bool dialogueIsPlaying { get; private set; }
    [HideInInspector] public bool canContinueToNextLine = false;

    [Header("UI Objects")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject continueIcon;

    [Header("Display Line Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Choices UI")]
    [SerializeField] private GameObject dialogueChoicesPanel;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private GameObject currentSource;
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
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueChoicesPanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update()
    {
        if (!dialogueIsPlaying) return;
        if (canContinueToNextLine  && currentStory.currentChoices.Count == 0 && InputManager.Instance.GetInteractPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        //currentSource = source;

        openedFrame = Time.frameCount;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        BindActions();

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueChoicesPanel.SetActive(false);
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

            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        openedFrame = Time.frameCount;

        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        continueIcon.SetActive(false);
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
        DisplayChoices();
        continueIcon.SetActive(true);
        canContinueToNextLine = true;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
            Debug.LogError("More choices were given that the UI can support. Number of choices given: " + currentChoices.Count);

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            dialogueChoicesPanel.SetActive(true);
            index++;
        }

        for (int i = index; i < choices.Length; i++)
            choices[i].gameObject.SetActive(false);

        if (currentChoices.Capacity > 0)
            StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        //EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        dialogueChoicesPanel.SetActive(false);
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void BindActions()
    {
        currentStory.BindExternalFunction("nextSequence", () => {
            GameManager.Instance.GetComponent<GameManager>().showBingoBallUI();
        });

        currentStory.BindExternalFunction("playRandomClipBingoBall", () => {
            AudioManager.Instance.GetComponent<AudioManager>().PlayRandomClipBingoBall();
        });

        currentStory.BindExternalFunction("playClipBingoBallSick", () => {
            AudioManager.Instance.GetComponent<AudioManager>().PlayClipBingoBallSick();
        });
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
                continue;
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();//.ToLower();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = splitTag[1].Trim();
                    break;
                case AUDIO_TAG:
                    if(tagValue == KNOCK_DOOR_TAG)
                        AudioManager.Instance.GetComponent<AudioManager>().PlayRandomClipKnockDoor();
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
}
