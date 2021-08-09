using DG.Tweening;
using UnityEngine;

public class HummerTrap : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float duration;
    [SerializeField] private float delayToStartAnimation;

    private void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(delayToStartAnimation);
        sequence.Append(transform.DOLocalRotate(endPosition, duration).SetEase(Ease.OutQuart));
        sequence.Append(transform.DOLocalRotate(startPosition, duration).SetEase(Ease.OutQuart));
        sequence.SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.Play("Death");
            other.GetComponent<Player>().GetDamage();
        }
    }
}
