using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StatusEffect
{
    public StatusEffect(StatusEffectData data)
    {
        name = data.name;
        description = data.Description;
        Icon = data.Icon;

        TempHealthAmount = data.TempHealthAmount;

        DOTAmount = data.DOTAmount;
        TickSpeed = data.TickSpeed;

        MovementAmount= data.MovementAmount;

        PhysicalDamageAmount= data.PhysicalDamageAmount;
        MagicDamageAmount= data.MagicDamageAmount;

        PhysicalArmorAmount= data.PhysicalArmorAmount;
        MagicArmorAmount= data.MagicArmorAmount;

        Duration= data.Duration;
        ParticleEffects= data.ParticleEffects;
    }

    protected Entity _entity;

    public string name = "Generic Effect"; // Not Implemented.
    public float Duration;
    public Sprite Icon = null;
    public string description = "Just your everyday effect."; // Not Implemented.

    [Header("Temp Movespeed and Temp Health")]
    public float MovementAmount;
    public int TempHealthAmount;

    [Header("Damage Overtime and Effect Speed")]
    public int DOTAmount;
    public float TickSpeed;

    [Header("Base Damage and Armor")]
    public int PhysicalDamageAmount;
    public int MagicDamageAmount;

    public int PhysicalArmorAmount;
    public int MagicArmorAmount;

    [Header("Additional Effects")]
    public GameObject ParticleEffects;

    public bool IsEnded = false;

    public void ApplyEffect()
    {
        _entity.TempPhysicalArmor += PhysicalArmorAmount;
        _entity.TempMagicArmor += MagicArmorAmount;

        _entity.TempSpeed += MovementAmount;

        _entity.TempPhysicalDamage += PhysicalDamageAmount;
        _entity.TempMagicDamage += MagicDamageAmount;

        _entity.TempHealth += TempHealthAmount;
        _entity.CurrentHealth += TempHealthAmount;

        _entity.CheckOverHealthThreshold();
    }

    public void UpdateEffect()
    {
        Duration -= Time.deltaTime;
        TickSpeed += TickSpeed * Time.deltaTime;


        TickEffects();
        CheckEffectCondition();
    }

    //Healing/Damage overtime
    public void TickEffects()
    {
        if(TickSpeed > 1)
        {
            TickSpeed = 0;

            _entity.ApplyHealing(DOTAmount);
            EmitParticleEffects();
        }
    }

    public void CheckEffectCondition()
    {
        if (Duration < 0)
        {
            //Duration hits zero. Remove all effects.
            _entity.TempPhysicalArmor -= PhysicalArmorAmount;
            _entity.TempMagicArmor -= MagicArmorAmount;

            _entity.TempSpeed -= MovementAmount;

            _entity.TempPhysicalDamage -= PhysicalDamageAmount;
            _entity.TempMagicDamage -= MagicDamageAmount;

            _entity.TempHealth -= TempHealthAmount;

            _entity.CheckOverHealthThreshold();

            IsEnded = true;
        }
    }

    public void EmitParticleEffects()
    {
        Debug.Log("Shooting Particle Effects. [UNIMPLEMENTED]");
    }
}