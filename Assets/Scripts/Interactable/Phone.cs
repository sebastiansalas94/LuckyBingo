using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    private DialogueTrigger dt;

    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite phoneGlow;

    [SerializeField] private Sprite hintIcon;
    [SerializeField] private string hintText = "Click to interact with the phone.";
    private bool showHint = true;
    private int hoveredCount = 0;

    // From Interface IInteractable
    public Sprite HintIcon => hintIcon;
    public string HintText => hintText;
    public bool ShowHint => showHint;
    int IInteractable.HoveredCount { get => hoveredCount; set => hoveredCount = value; }

    [SerializeField] private int maxHoveredHintLimit = 2;
    private int stage = 0;

    [SerializeField] private GameObject closeUpBackgroundReference;

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        closeUpBackgroundReference.SetActive(false);
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
        Debug.Log("Phone clicked");
        dt.StartDialogue();
        //ViewManager.Instance.DisableFrontRoomView();
        //closeUpBackgroundReference.SetActive(true);
    }

    public void ChangeSprite(bool hover)
    {
        if (hover)
        {
            backgroundImageReference.sprite = phoneGlow;
        }
    }
}
