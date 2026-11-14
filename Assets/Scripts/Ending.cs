using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    private DialogueTrigger dt;
    private SpriteRenderer sr;

    [Header("UI Objects")]
    [SerializeField] private GameObject dialoguePanel;

    [Header("Endings")]
    public TextAsset inkJsonEnding1;
    public TextAsset inkJsonEnding2;
    public TextAsset inkJsonEnding3;

    [Header("Endings")]
    public Sprite endingImage1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void StartEnding(int endingIndex)
    {
        RectTransform panel = dialoguePanel.GetComponent<RectTransform>();
        panel.anchoredPosition += new Vector2(0f, -445f);
        dialoguePanel.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.ForceExitDialogueMode();
        if(endingIndex == 0)
        {
            dt.StartDialogue(inkJsonEnding1);
        }
        else if (endingIndex == 1)
        {
            dt.StartDialogue(inkJsonEnding2);
        }
        else if (endingIndex == 2)
        {
            dt.StartDialogue(inkJsonEnding3);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndingImage()
    {
        sr.sprite = endingImage1;
        GameManager.Instance.GetComponent<GameManager>().EnablePlayAgainButton();
    }
}
