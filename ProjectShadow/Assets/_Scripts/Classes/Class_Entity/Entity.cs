using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private void Awake()
    {
        LoadEntityData();
    }

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

    private float _speed;


    //GETTERS AND SETTERS
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
    
    public void ApplyDamage(int DamageAmount, int ArmorAmount)
    {
        int CurrentDamage = DamageAmount;

        CurrentDamage = CurrentDamage - ArmorAmount;

        if (CurrentDamage <= 0)
        {
            CurrentDamage = 1; //Damage will always be one despite the armor.
        }
    }

    public void ApplyHealing(int HealingAmount)
    {
        CurrentHealth += HealingAmount;

        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void TargetDead()
    {

    }

    public bool IsDead()
    {
        if (CurrentHealth <= 0)
        {
            return true;
        }

        return false;
    }
}