using TMPro;
using UnityEngine;

public class BingoBall : MonoBehaviour
{

    [SerializeField] private TextMeshPro number;
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
