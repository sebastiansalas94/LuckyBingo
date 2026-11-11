using System.Collections;
using TMPro;
using UnityEngine;

public class MinigameBingoBall : MonoBehaviour
{

    [SerializeField] private TextMeshPro number;
    [SerializeField] public string numberText;

    [SerializeField] private float delay = 2f;
    [SerializeField] private bool winnerBall = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Start()
    {
        number.text = numberText;
        StartCoroutine(FallAfterDelay());
    }

    private IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public string GetNumber()
    {
        return numberText;
    }
}
