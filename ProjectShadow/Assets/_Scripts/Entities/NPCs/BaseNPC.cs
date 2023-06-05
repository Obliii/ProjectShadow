using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNPC
{

    public static int NumNPCs;
    public static int _FEAR;

    public int Health;
    public int Armor;

    public abstract void TakeDamage();
}
