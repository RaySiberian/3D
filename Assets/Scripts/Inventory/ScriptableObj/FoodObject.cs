using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory System/Items/Food")]
public class FoodObject : ItemObject
{
    public int restoreHeathValue;
    private void Awake()
    {
        type = ItemType.Food;
    }
}
