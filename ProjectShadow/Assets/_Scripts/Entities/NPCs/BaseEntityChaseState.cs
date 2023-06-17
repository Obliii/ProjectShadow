using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseEntityChaseState : BaseEntityState
{
    public override void EnterState()
    {
        Debug.Log("NPC Start Chase State");

        

    }
    public override void UpdateState()
    {

    }

    public override void ChangeState()
    {
        throw new System.NotImplementedException();
    }
}
