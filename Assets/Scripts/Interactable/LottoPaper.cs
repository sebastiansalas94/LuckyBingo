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

    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite lottoPaperGlow;

    [SerializeField] private GameObject closeUpBackgroundReference;

    [SerializeField] private int maxHoveredHintLimit = 2;
    private int interactionCount = 0;

    [SerializeField] private AudioClip paperSFX;

    private SpriteRenderer spriteRenderer;
    Transform[] allChildren;
    private bool showChilds = true;



    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        closeUpBackgroundReference.SetActive(false);
    }

    private void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (hoveredCount == maxHoveredHintLimit)
        {
            showHint = false;
        }
    }

    public void Interact()
    {
        Debug.Log("Lotto Paper clicked");
        //dt.StartDialogue();

        ViewManager.Instance.DisableFrontRoomView();
        closeUpBackgroundReference.SetActive(true);
        AudioManager.Instance.PlaySFX(paperSFX);
        interactionCount++;
    }

    public void ChangeSprite(bool hover)
    {
        if (hover)
        {
            backgroundImageReference.sprite = lottoPaperGlow;
        }
    }
}
