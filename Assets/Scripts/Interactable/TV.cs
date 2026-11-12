using System;
using Unity.Burst.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    private DialogueTrigger dt;

    [SerializeField] AudioClip bingoBallsRumbling;
    [SerializeField] GameObject ballSpinner;
    private BallAnimation ballAnimation;

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

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();

        if(ballSpinner != null)
        {
            ballAnimation = GetComponent<BallAnimation>();
        }
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
        Debug.Log("TV clicked");
        showHint = false;
        //GameManager.Instance.ShowHint(hintIcon, hintText);

        if (stage == 0) {
            RumbleBingoBall();
        }
        else if(stage == 1)
        {
            SelectBall();
        }
    }

    private void RumbleBingoBall()
    {
        ballSpinner.GetComponent<BallAnimation>().StartBallAnimation();
        AudioManager.Instance.PlaySFX(bingoBallsRumbling);
        stage = 1;
    }

    private void SelectBall()
    {
        AudioManager.Instance.StopSFX();
        ballSpinner.GetComponent<BallAnimation>().StopBallAnimation();
        stage = 2;

        dt.StartDialogue(GameManager.Instance.ballSequence);
    }

    public void SetStage(int newStage)
    {
        stage = newStage;
    }

    public void ResetStage()
    {
        stage = 0;
    }

    public void ChangeSprite(bool hover)
    {
        if (hover)
        {
            backgroundImageReference.sprite = tvScreenGlow;
        }
    }
}