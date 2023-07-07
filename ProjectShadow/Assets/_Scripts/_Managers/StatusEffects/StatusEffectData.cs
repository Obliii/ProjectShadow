using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect")]
public class StatusEffectData : ScriptableObject
{
    public string Name = "Generic Item";
    public Sprite Icon = null;
    public float Duration = 5f;
    [TextArea] public string Description = "Just your basic everyday item.";

    [Header("Temp Movespeed and Temp Health")]
    public float MovementAmount;
    public int TempHealthAmount;

    [Header("Damage Overtime and Effect Speed")]
    public int DOTAmount; //Damage Overtime
    public float TickSpeed;

    [Header("Base Damage")]
    public int PhysicalDamageAmount;
    public int MagicDamageAmount;

    [Header("Base Armor")]
    public int PhysicalArmorAmount;
    public int MagicArmorAmount;

    [Header("Additional Effects")]
    public GameObject ParticleEffects;
}
