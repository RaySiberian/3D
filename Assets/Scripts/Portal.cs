using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] 
    private CharacterMovement playerObj;
    [SerializeField] 
    private Transform teleportPosition;
    [SerializeField] 
    private float offsetTeleportPosition = 1;
    
    private Vector3 offset;
    
    private SoundManager soundManager;
    
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        playerObj = FindObjectOfType<CharacterMovement>();
        offset = teleportPosition.forward * offsetTeleportPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundManager.Play("Portal");
            playerObj.SetPlayerPosition(teleportPosition.position + offset, teleportPosition.rotation);
        }
    }
}
