using DG.Tweening;
using UnityEngine;

public class FallenBlock : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float fallingTime;
    [SerializeField] private float resetTrapTime;
    [SerializeField] private float waitForFallTime;

    private void StartFallAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(waitForFallTime);
        sequence.Append(transform.DOLocalMove(endPosition, fallingTime));
        sequence.AppendInterval(resetTrapTime);
        sequence.Append(transform.DOLocalMove(startPosition, fallingTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartFallAnimation();
        }
    }
}