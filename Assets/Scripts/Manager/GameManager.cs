using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance { get; private set; }
    [HideInInspector] List<int> lottoNumbers;
    [SerializeField] private TextMeshPro lottoNumberText;

    public int ballSequence = 0;
    public int ballSequenceStage = 0;

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
        for (int i = 0; i < 5; i++)
        {
            int number = Random.Range(01, 100);
            lottoNumberText.text += number.ToString("00") + " ";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
