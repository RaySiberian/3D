using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] 
    private Transform spawnPosition;
    private CharacterMovement characterMovement;

    private void Awake()
    {
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        characterMovement.SetPlayerPosition(spawnPosition.position,spawnPosition.rotation);   
    }
}
