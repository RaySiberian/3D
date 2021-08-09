using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup pausePanelCanvasGroup;
    private Tween fadeTween;
    private bool isPanelActive;
    private void Start()
    {
        FadeOut(0f);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePausePanelState();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 0f;
        }
    }

    private void ChangePausePanelState()
    {
        if (isPanelActive)
        {
            FadeOut(0.5f);
        }
        else
        {
            FadeIn(0.5f);
        }
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        fadeTween?.Kill(false);

        fadeTween = pausePanelCanvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private void FadeIn(float duration)
    {
        isPanelActive = true;
        Fade(1f,duration, () =>
        {
            pausePanelCanvasGroup.interactable = true;
            pausePanelCanvasGroup.blocksRaycasts = true;
            Time.timeScale = 0f;
        });
    }
    
    private void FadeOut(float duration)
    {
        Time.timeScale = 1f;
        isPanelActive = false;
        Fade(0f,duration, () =>
        {
            pausePanelCanvasGroup.interactable = false;
            pausePanelCanvasGroup.blocksRaycasts = false;
        });
    }
    
}
