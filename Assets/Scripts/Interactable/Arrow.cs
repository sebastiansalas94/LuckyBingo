using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Arrow : MonoBehaviour, IInteractable
{
    public enum Rooms
    {
        Center,
        Left,
        Right
    }
    [SerializeField] private Rooms RoomToGo = Rooms.Center;

    //We can ignore this for now, Arrows doesn't need hints
    public Sprite HintIcon => throw new System.NotImplementedException();
    public string HintText => throw new System.NotImplementedException();
    private bool showHint = false;
    public bool ShowHint => showHint;
    [SerializeField] public int hoveredCount = 0;
    int IInteractable.HoveredCount { get => hoveredCount; set => hoveredCount = value; }

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite arrowDefaultSprite;
    [SerializeField] private Sprite arrowGlowSprite;

    [SerializeField] private AudioClip clipSFX;

    private bool isHovered = false;

    public void Interact()
    {
        if(clipSFX != null)
            AudioManager.Instance.PlaySFX(clipSFX);
        GoToRoom();
        spriteRenderer.sprite = arrowDefaultSprite;
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSprite(bool newHoverValue)
    {
    }

    public void GoToRoom()
    {
        switch (RoomToGo)
        {
            case Rooms.Center:
                ViewManager.Instance.EnableFrontRoomView();
                break;
            case Rooms.Left:
                ViewManager.Instance.GoToLeftRoomView();
                break;
            case Rooms.Right:
                ViewManager.Instance.GoToRightRoomView();
                break;
        }
    }
}
