using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntityChaseState : BaseEntityState
{

    private GameObject _gameObject;
    public GameObject player;

    Vector2 LastSeenLocation;
    float TimeLastSeen;
    public override void EnterState()
    {
        Debug.Log("NPC Start Chase State");
    }
    public override void UpdateState()
    {

    }
}
