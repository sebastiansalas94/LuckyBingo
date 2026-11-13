using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TV : MonoBehaviour, IInteractable
{
    private DialogueTrigger dt;

    [SerializeField] AudioClip bingoBallsRumbling;
    [SerializeField] GameObject ballSpinner;
    private BallAnimation ballAnimation;

    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite tvScreenGlow;
    [SerializeField] private Sprite tvScreenDefault;

    [SerializeField] private Sprite hintIcon;
    [SerializeField] private string hintText = "Click to interact with the TV.";
    private bool showHint = true;
    private int hoveredCount = 0;

    // From Interface IInteractable
    public Sprite HintIcon => hintIcon;
    public string HintText => hintText;
    public bool ShowHint => showHint;
    int IInteractable.HoveredCount { get => hoveredCount; set => hoveredCount = value; }

    [SerializeField] private int maxHoveredHintLimit = 1;
    private int stage = 0;

    private SpriteRenderer parentSR;
    [SerializeField] private bool isSpinning = false;

    [SerializeField] private Sprite[] bingoSpinFrames;
    [SerializeField] private float fps = 8f;

    [SerializeField] private Sprite[] bingoBallOutFrames;
    private Coroutine routine;
    [SerializeField] private float frameTime = 0.25f;

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        //parentSR = transform.parent.GetComponent<SpriteRenderer>();
        //if (ballSpinner != null)
        //{
        //    ballAnimation = GetComponent<BallAnimation>();
        //}

        backgroundImageReference.sprite = tvScreenDefault;
    }
    private void Update()
    {
        if (hoveredCount == maxHoveredHintLimit)
        {
            showHint = false;
        }

        if(isSpinning)
        {
            int index = (int)(Time.time * fps) % bingoSpinFrames.Length;
            backgroundImageReference.sprite = bingoSpinFrames[index];
        }

        //if (isSelected)
        //{

        //}
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
        //ballSpinner.GetComponent<BallAnimation>().StartBallAnimation();
        stage = 1;
        isSpinning = true;
        AudioManager.Instance.PlaySFX(bingoBallsRumbling);
        FMODMusic.SetGlobalLabel("TV_on", "True");
        dt.StartDialogue(GameManager.Instance.ballSequence);
    }

    public void SelectBall()
    {
        isSpinning = false;
        Play(false);
        AudioManager.Instance.StopSFX();
        //ballSpinner.GetComponent<BallAnimation>().StopBallAnimation();
        stage = 2;


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
            //backgroundImageReference.sprite = tvScreenGlow;
        }
    }

    public void Play(bool loop)
    {
        Stop();
        routine = StartCoroutine(Animate(loop));
    }

    public void Stop()
    {
        if (routine != null)
            StopCoroutine(routine);
        routine = null;
    }

    private IEnumerator Animate(bool loop)
    {
        do
        {
            foreach (Sprite frame in bingoBallOutFrames)
            {
                backgroundImageReference.sprite = frame;
                yield return new WaitForSeconds(frameTime);
            }
        }
        while (loop);

        routine = null;
    }
}