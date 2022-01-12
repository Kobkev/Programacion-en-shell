using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Nota,
    Llave,
    Default

}
public abstract class ItemObject : ScriptableObject
{
    //public string Name;
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;

    public virtual string GetItemDescription()
    {
        return description;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public string description;
    public ItemType type;

    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        description = item.description;
        type = item.type;
    }
}



