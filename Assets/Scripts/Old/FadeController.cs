using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    public static FadeController Instance { get; private set; }

    [SerializeField] private CanvasGroup fadeGroup;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        fadeGroup.alpha = 0;
        fadeGroup.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut(float duration = 1f)
    {
        fadeGroup.gameObject.SetActive(true);
        fadeGroup.alpha = 0;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = t / duration;
            yield return null;
        }

        fadeGroup.alpha = 1;
    }

    public IEnumerator FadeIn(float duration = 1f)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = 1 - (t / duration);
            yield return null;
        }

        fadeGroup.alpha = 0;
        fadeGroup.gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
