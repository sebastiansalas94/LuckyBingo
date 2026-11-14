using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IntroSequence : MonoBehaviour
{
    [SerializeField, TextArea] private string[] lines;
    [SerializeField] private TMP_Text text;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private float fadeTime = 0.8f;
    [SerializeField] private float holdTime = 2.5f;
    [SerializeField] private UnityEvent onFinished;

    private int lineStartFrame;

    public void StartIntroSequence()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        foreach (string line in lines)
        {
            text.text = line;
            lineStartFrame = Time.frameCount;

            yield return Fade(0f, 1f);
            //yield return Hold();
            yield return Fade(1f, 0f);
        }

        onFinished.Invoke();
    }

    private IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            group.alpha = Mathf.Lerp(from, to, t / fadeTime);
            yield return null;
        }
        group.alpha = to;
    }
}
