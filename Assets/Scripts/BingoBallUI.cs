using TMPro;
using UnityEngine;

public class BingoBallUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI number;
    [SerializeField] public string numberText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        number.text = numberText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
