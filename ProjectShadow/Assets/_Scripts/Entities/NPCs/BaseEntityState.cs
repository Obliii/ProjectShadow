using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntityState
{
    private Transform m_transform;
    public Animator m_animator;
    public abstract void EnterState();
    public abstract void UpdateState();
}
