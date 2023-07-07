using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Entity")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public Animator animator;
    public CharacterPortrait portraitsheet;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Base Armor")]
    public int basePhysicalArmor;
    public int baseMagicArmor;

    [Header("Base Damage")]
    public int basePhysicaldamage;
    public int baseMagicdamage;

    [Header("Base Speed")]
    public float speed;
}
