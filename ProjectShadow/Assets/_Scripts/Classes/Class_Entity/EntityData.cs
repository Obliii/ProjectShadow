using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Entity")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public Animator animator;
    public CharacterPortrait portraitsheet;

    public int maxHealth;
    public int currentHealth;

    public int basePhysicalArmor;
    public int baseMagicArmor;

    public int basePhysicaldamage;
    public int baseMagicdamage;

    public float speed;
}
