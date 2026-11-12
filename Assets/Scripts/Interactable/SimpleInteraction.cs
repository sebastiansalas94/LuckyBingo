using UnityEngine;

public class SimpleInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private string name;
    private SimpleDialogueTrigger dt;

    public Sprite HintIcon => throw new System.NotImplementedException();

    public string HintText => throw new System.NotImplementedException();
    private bool showHint = false;
    private int hoveredCount = 0;
    public bool ShowHint => showHint;
    int IInteractable.HoveredCount { get => hoveredCount; set => hoveredCount = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dt = GetComponent<SimpleDialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log(name + " clicked");
        dt.StartDialogue();
    }

    public void ChangeSprite(bool isHovered)
    {
    }
}
