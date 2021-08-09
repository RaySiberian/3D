using DG.Tweening;
using UnityEngine;

public class ButtonBridge : MonoBehaviour
{
    [Header("Button")] [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float animationDuration;
    [SerializeField] private float delayToReset;

    [Header("BridgeBlocks")] [SerializeField]
    private GameObject[] bridgeParts;
    [SerializeField] private Vector3 moveOffset;
    [SerializeField] private float delayToStartPartAnimation;
    [SerializeField] private float partAnimationTime;
    [SerializeField] private float partDelayToReset;

    private void StartButtonAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(endPosition, animationDuration));
        StartBrideAnimation();
        sequence.AppendInterval(delayToReset);
        sequence.Append(transform.DOLocalMove(startPosition, animationDuration));
    }

    private void StartBrideAnimation()
    {
        foreach (var part in bridgeParts)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(delayToStartPartAnimation);
            sequence.Append(part.transform.DOLocalMove(part.transform.localPosition + moveOffset, partAnimationTime));
            sequence.AppendInterval(partDelayToReset);
            sequence.Append(part.transform.DOLocalMove(part.transform.localPosition, partAnimationTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartButtonAnimation();
        }
    }
}