using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance { get; private set; }
    [HideInInspector] List<int> lottoNumbers;
    [SerializeField] private TextMeshPro lottoNumberText;

    [Header("UI")]
    [SerializeField] private GameObject lottoNumberPanel;
    [SerializeField] private GameObject lottoNumberUI;
    private List<GameObject> listLottoNumberUI;

    [Header("Gameplay Objects")]
    [SerializeField] private PointAndClick PaC;//PointAndClick
    [SerializeField] private GameObject Tv;
    private TV TvScript;

    [SerializeField] private SpriteRenderer backgroundImageReference;
    [SerializeField] private Sprite tvScreen;
    public int ballSequence { get; private set; }
    public int ballSequenceStage = 0;
    private string ballPicked = "";

    [SerializeField] private ControlHint Hint;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballSequence = 0;

        //AudioManager.Instance.PlayDefaultMusic();

        if (Tv != null)
        {
            TvScript = Tv.GetComponent<TV>();
        }

        for (int i = 0; i < 5; i++)
        {
            int number = Random.Range(01, 100);
            lottoNumberText.text += number.ToString("00") + " ";
        }

        listLottoNumberUI = new List<GameObject>();
        lottoNumberPanel.SetActive(false);
        foreach (Transform child in lottoNumberUI.transform)
        {
            listLottoNumberUI.Add(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBingoBallPicked(string numberText)
    {
        ballPicked = numberText;
    }

    public void showBingoBallUI()
    {
        if (ballSequence == 5) return;

        lottoNumberPanel.SetActive(true);
        listLottoNumberUI[ballSequence].GetComponent<BingoBallUI>().numberText = ballPicked;
        listLottoNumberUI[ballSequence].SetActive(true);
        ballSequence++;
        TvScript.ResetStage();
    }

    public void EnablePaCInteract()
    {
        PaC.SetCanInteract(true);//canInteract = true;
    }

    public void DisablePaCInteract()
    {
        PaC.SetCanInteract(false);
    }

    // Should the GameManager be responsible for showing hints? Maybe it should be the UIManager's responsibility. But for now, let's keep it here.
    public void ShowHint(Sprite hintIcon, string hintText)
    {
        Hint.Show(hintIcon, hintText);
    }

    public void HideHint(Sprite hintIcon, string hintText)
    {
        Hint.Hide();
    }

    public void ResetBackground()
    {
        if(backgroundImageReference != null)
            backgroundImageReference.sprite = tvScreen;
    }
}
