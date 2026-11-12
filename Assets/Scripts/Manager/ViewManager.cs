using UnityEngine;

public class ViewManager : MonoBehaviour
{

    [SerializeField] private GameObject Tv;
    [SerializeField] private GameObject LottoPaper;
    [SerializeField] private GameObject LottoPaperCloseUp;

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
    }

    public void EnableFrontRoomView() {
        if (Tv != null)
            Tv.SetActive(true);
        if (LottoPaper != null)
            LottoPaper.SetActive(true);

        if (LottoPaperCloseUp != null)
            LottoPaperCloseUp.SetActive(false);
    }
}
