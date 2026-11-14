using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //3, 7, 10, 15, 42
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

    [SerializeField] private GameObject playAgainButton;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballSequence = 0;
        if(playAgainButton != null)
            playAgainButton.SetActive(false);
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

    public void SetBingoBallPicked()
    {
        // Magic Numbers, yay!
        if (ballSequence == 0)
            ballPicked = "03";
        else if (ballSequence == 1)
            ballPicked = "07";
        else if (ballSequence == 2)
            ballPicked = "10";
        else if (ballSequence == 3)
            ballPicked = "15";
        else if (ballSequence == 4)
            ballPicked = "42";
        else
            ballPicked = "";
    }

    public void showBingoBallUI()
    {
        if (ballSequence == 5) return;

        SetBingoBallPicked();
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
        ViewManager.Instance.WhichRoom();
        //if(backgroundImageReference != null)
        //    backgroundImageReference.sprite = tvScreen;
    }

    public void SelectBall()
    {
        TvScript.SelectBall();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void EnablePlayAgainButton()
    {
        playAgainButton.SetActive(true);
    }
}
