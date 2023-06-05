using System.Collections;
using System.Collections.Generic;

public class Entity
{
    public Entity(Inventory entityinventory = null)
    {
        //stats = entityhealth;
        inventory = entityinventory;
    }
    
    public Stats stats;


    public Inventory inventory;

    
}

public class Stats
{
    public Stats(int Health = 100, int PhysicalArmor = 2, int MagicArmor = 1, int BasePhysicalDamage = 5, int BaseMagicDamage = 0)
    {
        maxHealth = Health;
        physicalarmor = PhysicalArmor;
        magicarmor = MagicArmor;
        basephysicaldamage = BasePhysicalDamage;
        basemagicdamage = BaseMagicDamage;
    }

    //These are base values, armor items will be able to change this.
    private int maxHealth;
    private int currentHealth;

    private int physicalarmor;
    private int magicarmor;

    private int basephysicaldamage;
    private int basemagicdamage;


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
        currentHealth += HealingAmount;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TargetDead()
    {

    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }

        return false;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetBasePhysicalArmor()
    {
        return physicalarmor;
    }

    public int GetBaseMagicArmor()
    {
        return magicarmor;
    }

    public int GetBasePhysicalDamage()
    {
        return basephysicaldamage;
    }

    public int GetBaseMagicDamage()
    {
        return basemagicdamage;
    }
}