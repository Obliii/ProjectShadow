using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntityStationaryState : BaseEntityState
{
    public override void EnterState()
    {
        Debug.Log("NPC Start Stationary State");
    }
    public override void UpdateState()
    {

    }
}
