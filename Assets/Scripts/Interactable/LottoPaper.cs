using Ink.Parsed;
using UnityEngine;

public class LottoPaper : MonoBehaviour, IInteractable
{
    private DialogueTrigger dt;

    [SerializeField] private Sprite hintIcon;
    [SerializeField] private string hintText = "Click to interact with the Lotto Paper.";
    private bool showHint = true;
    [SerializeField] public int hoveredCount = 0;
    // From Interface IInteractable
    public Sprite HintIcon => hintIcon;
    public string HintText => hintText;
    public bool ShowHint => showHint;
    int IInteractable.HoveredCount { get => hoveredCount; set => hoveredCount = value; }

    [SerializeField] private int maxHoveredHintLimit = 2;
    private int interactionCount = 0;

    [SerializeField] private AudioClip paperSFX;

    private SpriteRenderer spriteRenderer;
    Transform[] allChildren;
    private bool showChilds = true;

    private void Update()
    {
        ShowHidePaper();

        if (hoveredCount == maxHoveredHintLimit)
        {
            showHint = false;
        }
    }

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
    }

    public void Interact()
    {
        Debug.Log("Lotto Paper clicked");
        dt.StartDialogue();

        interactionCount++;
    }

    public void ShowHidePaper()
    {
        if (InputManager.Instance.GetPaperPressed())
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            showChilds = !showChilds;
            
            foreach (Transform child in allChildren)
            {
                if (child != transform)
                {
                    child.gameObject.SetActive(showChilds);
                }
            }

            AudioManager.Instance.PlaySFX(paperSFX);
        }
    }


}
