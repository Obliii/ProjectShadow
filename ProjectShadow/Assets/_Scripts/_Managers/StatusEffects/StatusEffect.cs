using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class StatusEffect
{
    protected Entity _entity;

    public string _name = "Generic Effect"; // Not Implemented.
    public Sprite _statusIcon = null; // Not Implemented.
    public float _duration = 5f;
    [TextArea]
    public string _description = "Just your everyday effect."; // Not Implemented.
    public bool IsEnded = false;

    public abstract void ApplyEffect();
    public abstract void UpdateEffect();
    public abstract void CheckEffectCondition();
}