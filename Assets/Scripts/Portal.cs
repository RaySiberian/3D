using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private CharacterMovement playerObj;
    [SerializeField] private Transform teleportPosition;
    [SerializeField] private Portal otherPortal;

    public bool isReady;
    
    private void Awake()
    {
        isReady = true;
        playerObj = FindObjectOfType<CharacterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || !isReady) return;
        
        SoundManager.Instance.Play("Portal");
        otherPortal.isReady = false;
        playerObj.SetPlayerPosition(teleportPosition.position, teleportPosition.rotation);
    }

    private void OnTriggerExit(Collider other)
    {
        isReady = true;
    }
}
