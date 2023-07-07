using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class InventoryItem
{
    public InventoryItem(InventoryItemData data)
    {
        itemName = data.itemName;
        id = data.id;
        uses = data.uses;
        icon = data.icon;
        description = data.description;
    }

    protected Entity _entity;
    
    public string itemName;
    public int id;
    public int uses;
    public Sprite icon;
    public string description;
}

[CreateAssetMenu(menuName = "Items/New Generic Item")]
public abstract class InventoryItemData : ScriptableObject
{
    protected Entity _entity;

    public int id;
    public int uses;
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;

    public abstract void UseItem();
}

[CreateAssetMenu(menuName = "Items/New Health Item")]
public class HealthItem : InventoryItemData
{
    public int health;
    public override void UseItem()
    {
        _entity.ApplyHealing(health);
    }
}

public class DamagingItem : InventoryItemData
{
    public int health;
    public bool ignoresTempHP;
    public override void UseItem()
    {
        _entity.ApplyMagicDamage(health, false, ignoresTempHP);
    }
}

[CreateAssetMenu(menuName = "Items/New Consumable Item")]
public class ConsumableItem : InventoryItemData
{
    [Header("Immediate Effects.")]
    public int HealthChange;

    [Header("Status Effect")]
    public StatusEffectData ItemStatusData;
    public override void UseItem()
    {
        _entity.ApplyHealing(HealthChange);

        if(ItemStatusData != null)
        {
            _entity.ApplyActiveEffect(ItemStatusData);
        }
    }   
}

[CreateAssetMenu(menuName = "Items/New Equipment")]
public class EquipmentItem : InventoryItemData
{
    public override void UseItem()
    {
        
    }
}