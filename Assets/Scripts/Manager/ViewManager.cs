using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [Header("Front Room View")]
    [SerializeField] private GameObject FrontRoomView;
    [SerializeField] private GameObject FrontRoomParent;
    [SerializeField] private GameObject Tv;
    [SerializeField] private GameObject LottoPaper;
    [SerializeField] private GameObject Chips;

    [Header("Left Room View")]
    [SerializeField] private GameObject LeftRoomView;

    [Header("Right Room View")]
    [SerializeField] private GameObject RightRoomView;

    [Header("Close Up View")]
    [SerializeField] private GameObject LottoPaperCloseUp;
    [SerializeField] private GameObject TvCloseUp;

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
    }

    public void GoToFrontRoomView()
    {
        DisableCloseUps();
        EnableFrontRoomView();
    }

    public void GoToLeftRoomView()
    {
        DisableFrontRoomView();
        EnableLeftRoomView();
    }

    public void GoToRightRoomView()
    {
        DisableFrontRoomView();
        EnableRightRoomView();
    }
}
