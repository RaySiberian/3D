using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Quaternion spawnRotation;
    public float range;
    public InventoryObject inventory;

    private Camera mainCamera;
    public static event Action OnItemAdded;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
        mainCamera = Camera.main;
    }

    public void GetDamage()
    {
        characterMovement.SetPlayerPosition(spawnPosition, spawnRotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            inventory.Load();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    private void Shot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit,range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void OnEnable()
    {
        CharacterMovement.OnTriggeredItem += CharacterMovementOnTriggeredItem;
    }

    private void OnDisable()
    {
        CharacterMovement.OnTriggeredItem -= CharacterMovementOnTriggeredItem;
    }

    private void CharacterMovementOnTriggeredItem(ItemObject item, int amount)
    {
        inventory.AddItem(item, amount);
        OnItemAdded?.Invoke();
    }
}