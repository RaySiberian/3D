using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float attackBonus;
    public float defenceBonus;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
