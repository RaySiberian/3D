using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ISerializationCallbackReceiver нужен для сериалиции SO
/// </summary>
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    private ItemDataBaseObject dataBase;
    public List<InventorySlot> container = new List<InventorySlot>();
    public string savePath;

    private void OnEnable()
    {
        //Сериалайз филд тоже работает, не понятно почему именно такой способ
#if UNITY_EDITOR
        dataBase = (ItemDataBaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Inventory/DataBase",typeof(ItemDataBaseObject));
        #else
        dataBase = Resources.Load<ItemDataBaseObject>("Inventory/DataBase");
#endif
    }

    public void AddItem(ItemObject item, int amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == item)
            {
                container[i].AddAmount(amount);
                return;
            }
        }
        container.Add(new InventorySlot(dataBase.GetId[item],item, amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file,saveData);
        file.Close();
    }
    
    //TODO При загрузке не обновляется UI, т.к. обновление от ивента
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            file.Close();
        }
    }
    
    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < container.Count; i++)
        {
            container[i].item = dataBase.GetItem[container[i].ID];
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;

    public InventorySlot(int id, ItemObject item, int amount)
    {
        ID = id;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}