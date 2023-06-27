using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public abstract void UseItem();
    
}
