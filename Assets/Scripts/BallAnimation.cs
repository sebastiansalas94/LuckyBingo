using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
    [SerializeField] private List<Transform> balls;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 90f; // degrees per second

    private float angle;
    private bool isSpinning = false;

    private void Start()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            float offset = 360f / balls.Count * i;
            float rad = (angle + offset) * Mathf.Deg2Rad;

            balls[i].localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
        }
    }

    private void Update()
    {
        if (!isSpinning) return;

        angle += speed * Time.deltaTime;

        for (int i = 0; i < balls.Count; i++)
        {
            float offset = 360f / balls.Count * i;
            float rad = (angle + offset) * Mathf.Deg2Rad;

            balls[i].localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
        }
    }

    public void StartBallAnimation()
    {
        isSpinning = true;
    }

    public void StopBallAnimation()
    {
        isSpinning = false;
        Transform picked = balls[Random.Range(0, balls.Count)];
        picked.localScale *= 1.5f;
        GameManager.Instance.SetBingoBallPicked(picked.gameObject.GetComponent<BingoBall>().GetNumber());
    }
}
