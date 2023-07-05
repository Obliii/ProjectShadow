using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private void Awake()
    {
        LoadEntityData();
    }

    //Getting a list of InventoryItems to get the ActiveEffects from.
    public List<StatusEffect> Effects = new List<StatusEffect>();

    //public Inventory inventory;
    public EntityData CharacterData;

    //Base Entity Variables
    private string _name;
    private Animator _animator;

    private CharacterPortrait _portraiticon;

    private int _maxHealth;
    private int _currentHealth;

    private int _physicalArmor;
    private int _magicArmor;

    private int _basePhysicaldamage;
    private int _baseMagicdamage;

    private int _tempPhysicalArmor;
    private int _tempMagicArmor;
    private int _tempPhysicalDamage;
    private int _tempHealth;
    private float _tempSpeed;

    private float _speed;


    //GETTERS AND SETTERS. Default Values
    public string Name { get { return _name; } set { _name = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }
    public CharacterPortrait CharacterIcon { get { return _portraiticon; } set { _portraiticon = value; } }
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    public int BasePhysicalArmor { get { return _physicalArmor; } set { _physicalArmor = value; } }
    public int BaseMagicArmor { get { return _magicArmor; } set { _magicArmor = value; } }
    public int BasePhysicalDamage { get { return _basePhysicaldamage; } set { _basePhysicaldamage = value; } }
    public int BaseMagicDamage { get { return _baseMagicdamage; } set { _baseMagicdamage = value; } }
    public float BaseSpeed { get { return _speed; } set { _speed = value; } }
    //Getters and setters. Temporary Values for items to give. 
    public int TempPhysicalArmor { get { return _tempPhysicalArmor; } set { _tempPhysicalArmor = value; } }
    public int TempMagicArmor { get { return _tempMagicArmor; } set { _tempMagicArmor = value;} }
    public int TempPhysicalDamage { get { return _tempPhysicalDamage; } set { _tempPhysicalDamage = value; } }
    public int TempHealth { get { return _tempHealth; } set { _tempHealth = value; } }
    public float TempSpeed { get { return _tempSpeed; } set { _tempSpeed = value; } }

    public int TotalPhysicalArmor { get { return _physicalArmor + _tempPhysicalArmor; } }
    public int TotalMagicArmor { get { return _magicArmor + _tempMagicArmor;} }


    public void LoadEntityData()
    {
        Name = CharacterData.name;
        Animator = CharacterData.animator;
        CharacterIcon = CharacterData.portraitsheet;
        MaxHealth = CharacterData.maxHealth;
        CurrentHealth = CharacterData.currentHealth;
        BasePhysicalArmor = CharacterData.basePhysicalArmor;
        BaseMagicArmor = CharacterData.baseMagicArmor;
        BasePhysicalDamage = CharacterData.baseMagicdamage;
        BaseMagicDamage = CharacterData.baseMagicdamage;
        BaseSpeed = CharacterData.speed;
    }
    
    public void ApplyPhysicalDamage(int DamageAmount, bool AccountForArmor = true, bool IsIgnoringTempHealth = false)
    {
        int CurrentDamage = DamageAmount;

        if(AccountForArmor)
        CurrentDamage = CurrentDamage - TotalPhysicalArmor;

        if (TempHealth > 0 && IsIgnoringTempHealth)
        {
            while (CurrentDamage != 0 && TempHealth != 0)
            {
                TempHealth -= 1;
                CurrentDamage -= 1;
            }
        }

        if (CurrentDamage <= 0)
        {
            CurrentDamage = 1; //Damage will always be one despite the armor.
        }

        CurrentHealth -= CurrentDamage;
    }

    public void ApplyMagicDamage(int DamageAmount, bool AccountForArmor = true, bool IsIgnoringTempHealth = false)
    {
        int CurrentDamage = DamageAmount;

        if (AccountForArmor)
        {
            CurrentDamage = CurrentDamage - TotalMagicArmor;
        }

        if (TempHealth > 0 && IsIgnoringTempHealth)
        {
            while(CurrentDamage != 0 && TempHealth != 0) 
            {
                TempHealth -= 1;
                CurrentDamage -= 1;
            }
        }

        if (CurrentDamage <= 0)
                CurrentDamage = 1; //Damage will always be one despite the armor.

        CurrentHealth -= CurrentDamage;
    }

    public void ApplyHealing(int HealingAmount)
    {
        if(CurrentHealth < MaxHealth)
        {
            CurrentHealth += HealingAmount;
        }


        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void UpdateEffects()
    {
        for(int x = 0; x < Effects.Count; ++x)
        {
            Effects[x].UpdateEffect();

            if (Effects[x].IsEnded) {
                Effects.RemoveAt(x);
            }

        }
    }

    public void ClearAllEffects()
    {
        Effects.Clear();
    }

    public void ApplyActiveEffect(StatusEffect effect)
    {
        Effects.Add(effect);

        effect.ApplyEffect();
    }

    public void TargetDead()
    {

    }

    public void CheckOverHealthThreshold()
    {
        if(CurrentHealth > MaxHealth + TempHealth)
        {
            CurrentHealth = MaxHealth + TempHealth;
        }
    }

    public bool IsDead()
    {
        if (CurrentHealth <= 0)
        {
            return true;
        }

        return false;
    }

    public bool PlayerInCombat()
    {
        if(GameManager.IsInCombat)
        {
            return true;
        }

        return false;
    }
}