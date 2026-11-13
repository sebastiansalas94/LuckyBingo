using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public enum Rooms
    {
        Center,
        Left,
        Right
    }
    private Rooms CurrentRoom = Rooms.Center;

    [Header("Front Room View")]
    [SerializeField] private GameObject FrontRoomView;
    [SerializeField] private GameObject FrontRoomParent;
    [SerializeField] private Sprite FrontRoomBackground;
    [SerializeField] private GameObject Tv;
    [SerializeField] private GameObject LottoPaper;
    [SerializeField] private GameObject Chips;

    [Header("Left Room View")]
    [SerializeField] private GameObject LeftRoomView;
    [SerializeField] private Sprite LeftRoomViewBackground;

    [Header("Right Room View")]
    [SerializeField] private GameObject RightRoomView;
    [SerializeField] private Sprite RightRoomViewBackground;

    [Header("Close Up View")]
    [SerializeField] private GameObject LottoPaperCloseUp;
    [SerializeField] private GameObject TvCloseUp;
    [SerializeField] private GameObject WindowCloseUp;

    [HideInInspector] public static ViewManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    public void DisableFrontRoomView()
    {
        if (Tv != null)
            Tv.SetActive(false);
        if (LottoPaper != null)
            LottoPaper.SetActive(false);
        if (Chips != null)
            Chips.SetActive(false);
        if (FrontRoomParent != null)
            FrontRoomParent.SetActive(false);
        if (FrontRoomView != null)
            FrontRoomView.SetActive(false);
    }

    public void EnableFrontRoomView() {
        //Turn on all items in front room view
        if (FrontRoomView != null)
            FrontRoomView.SetActive(true);
        if (FrontRoomParent != null)
            FrontRoomParent.SetActive(true);
        if (Tv != null)
            Tv.SetActive(true);
        if (LottoPaper != null)
            LottoPaper.SetActive(true);
        if (Chips != null)
            Chips.SetActive(true);


        //Turn off all other views
        if (LottoPaperCloseUp != null)
            LottoPaperCloseUp.SetActive(false);

        if (TvCloseUp != null)
            TvCloseUp.SetActive(false);

        if (LeftRoomView)
            LeftRoomView.SetActive(false);

        if (RightRoomView)
            RightRoomView.SetActive(false);
    }

    public void DisableRightRoom()
    {
        if (RightRoomView)
            RightRoomView.SetActive(false);
    }

    public void EnableLeftRoomView()
    {
        if (LeftRoomView)
            LeftRoomView.SetActive(true);
    }

    public void EnableRightRoomView()
    {
        if (RightRoomView)
            RightRoomView.SetActive(true);
    }

    public void DisableCloseUps()
    {
        if(LottoPaperCloseUp != null) { }
            LottoPaperCloseUp.SetActive(false);

        if (TvCloseUp != null)
            TvCloseUp.SetActive(false);

        if (WindowCloseUp != null)
            WindowCloseUp.SetActive(false);
    }

    public void GoToFrontRoomView()
    {
        CurrentRoom = Rooms.Center;
        DisableCloseUps();
        EnableFrontRoomView();
    }

    public void GoToLeftRoomView()
    {
        CurrentRoom = Rooms.Left;
        DisableFrontRoomView();
        EnableLeftRoomView();
    }

    public void GoToRightRoomView()
    {
        CurrentRoom = Rooms.Right;
        DisableCloseUps();
        DisableFrontRoomView();
        EnableRightRoomView();
    }

    public void WhichRoom()
    {
        switch (CurrentRoom)
        {
            case Rooms.Center:
                FrontRoomView.GetComponent<SpriteRenderer>().sprite = FrontRoomBackground;
                break;
            case Rooms.Left:
                LeftRoomView.GetComponent<SpriteRenderer>().sprite = LeftRoomViewBackground;
                break;
            case Rooms.Right:
                RightRoomView.GetComponent<SpriteRenderer>().sprite = RightRoomViewBackground;
                break;
        }
    }
}
