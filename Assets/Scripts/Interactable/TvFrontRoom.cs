using UnityEngine;

public class TvFrontRoom : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite tvScreenGlow;

    [SerializeField] private Sprite hintIcon;
    [SerializeField] private string hintText = "Click to interact with the TV.";
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
        Debug.Log("Lotto Paper clicked");

        ViewManager.Instance.DisableFrontRoomView();
        closeUpBackgroundReference.SetActive(true);
    }

    public void ChangeSprite(bool hover)
    {
        if (hover)
        {
            backgroundImageReference.sprite = tvScreenGlow;
        }
    }
}
