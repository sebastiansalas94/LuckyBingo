using UnityEngine;

public class Window : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite windowGlow;

    [SerializeField] private Sprite hintIcon;
    [SerializeField] private string hintText = "Click to peek out the window.";
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
        Debug.Log("Window clicked");

        ViewManager.Instance.DisableRightRoom();
        closeUpBackgroundReference.SetActive(true);
    }

    public void ChangeSprite(bool hover)
    {
        if (hover)
        {
            backgroundImageReference.sprite = windowGlow;
        }
    }
}
