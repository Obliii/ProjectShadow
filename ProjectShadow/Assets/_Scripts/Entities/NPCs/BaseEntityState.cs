using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntityState
{
    protected Animator m_Animator;
    protected Vector2 m_Vector;
    protected GameObject m_GameObject;
    protected EntityFieldOfView m_FOV;
    protected Entity m_Entity;

    protected EntityStateManager m_StateManager;

    public BaseEntityState()
    {

    }

    public abstract void EnterState();
    public abstract void UpdateState();

    public abstract void ChangeState();

}
