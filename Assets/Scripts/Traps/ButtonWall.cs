using System;
using DG.Tweening;
using UnityEngine;

public class ButtonWall : MonoBehaviour
{
    [Header("Button")]
    public float animationDelayButton;
    public float animationTimeButton;

    public Vector3 startPositionButton;
    public Vector3 endPositionButton;
    
    [Header("Wall")]
    public float animationDelay;
    public float animationTime;
    public float shakeDuration;
    public float shakeStrength;
    
    public Vector3 startPosition;
    public Vector3 endPosition;

    public Transform wallTransform;
    

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    
    private void StartButtonAnimation()
    {
        soundManager.Play("Button");
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(endPositionButton, animationTimeButton));
        StartWallAnimation();
        sequence.AppendInterval(animationDelayButton);
        sequence.Append(transform.DOLocalMove(startPositionButton, animationTimeButton));
    }

    private void StartWallAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(animationDelay); // Задержка до анимации
        sequence.Append(wallTransform.transform.DOLocalMove(endPosition, animationTime)); // Анимацаия по времени
        sequence.AppendInterval(animationDelay / 2);
        sequence.Append(wallTransform.transform.DOShakePosition(shakeDuration, shakeStrength));
        sequence.AppendInterval(0.2f);
        sequence.Append(wallTransform.transform.DOLocalMove(startPosition, animationTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartButtonAnimation();
        }
    }
}
