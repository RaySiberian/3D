using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed;

    private void Start()
    {
        StartRotationAnimation();
    }

    private void StartRotationAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.transform.DORotate(new Vector3(90,0,180), rotationSpeed));
        sequence.SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.Play("Coin");
            LevelManager.Instance.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
