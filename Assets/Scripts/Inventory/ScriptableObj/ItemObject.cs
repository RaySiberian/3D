using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    [TextArea(15, 20)] public string description;
    public GameObject prefab;
    public ItemType type;
}
