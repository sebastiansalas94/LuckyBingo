using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [Header("Front Room View")]
    [SerializeField] private GameObject Tv;
    [SerializeField] private GameObject LottoPaper;
    [SerializeField] private GameObject Chips;

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
    }

    public void EnableFrontRoomView() {
        if (Tv != null)
            Tv.SetActive(true);
        if (LottoPaper != null)
            LottoPaper.SetActive(true);
        if (Chips != null)
            Chips.SetActive(true);

        if (LottoPaperCloseUp != null)
            LottoPaperCloseUp.SetActive(false);

        if (TvCloseUp != null)
            TvCloseUp.SetActive(false);
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
}
