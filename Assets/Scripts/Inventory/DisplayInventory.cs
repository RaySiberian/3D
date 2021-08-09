using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    [SerializeField] private int X_START;
    [SerializeField] private int Y_START;
    
    [SerializeField] private int X_SPACE_BETWEEN_ITEM;
    [SerializeField] private int NUMBER_OF_COLUMN;
    [SerializeField] private int Y_SPACE_BETWEEN_ITEMS;

    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i]))
            {
                itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    inventory.container[i].amount.ToString();
            }
            else
            {
                var obj = Instantiate(inventory.container[i].item.prefab,Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.container[i],obj);
            }
        }
    }
    
    //TODO дублирование кода
    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventory.container[i].item.prefab,Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.container[i],obj);
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3( X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)),
            (Y_START + ( -Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN))), 0f);
    }
    
    
    private void OnEnable()
    {
        Player.OnItemAdded += UpdateDisplay;
    }

    private void OnDisable()
    {
        Player.OnItemAdded -= UpdateDisplay;
    }
    
   
}
