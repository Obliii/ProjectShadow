using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFieldOfView : MonoBehaviour
{

    public float Radius = 5f;
    [Range(1, 360)] public float angle = 45f;

    public LayerMask TargetLayer;
    public LayerMask ObstructionLayer;

    public GameObject PlayerRef;

    public bool CanSeePlayer { get; private set; }

    private RaycastHit2D hit;


    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait;
            FOV();
        }
    }
    private void FOV()
    {
        Collider2D[] RangeCheck = Physics2D.OverlapCircleAll(transform.position, Radius, TargetLayer);

        if(RangeCheck.Length > 0)
        {
            Transform target = RangeCheck[0].transform;
            Vector2 DirectionTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(transform.up, DirectionTarget) < angle * 0.5)
            {
                float DistanceTarget = Vector2.Distance(transform.position, target.position);

                hit = Physics2D.Raycast(transform.position, DirectionTarget, DistanceTarget, ObstructionLayer);
                if (!hit)
                {
                    CanSeePlayer = true;
                    return;
                }
            }
        }

        CanSeePlayer = false;
    }

    /// <summary>
    /// DEBUGGING GIZMOSA
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, Radius);

        Vector3 Angle01 = DirectionFromAngle(transform.eulerAngles.z, -angle / 2);
        Vector3 Angle02 = DirectionFromAngle(transform.eulerAngles.z, angle / 2);

        

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Angle01 * Radius);
        Gizmos.DrawLine(transform.position, transform.position + Angle02 * Radius);

        if (CanSeePlayer && !hit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, PlayerRef.transform.position);
        }
        else if(hit)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, hit.point);
        }

    }

    private Vector2 DirectionFromAngle(float EulerY, float AngleInDegrees)
    {
        AngleInDegrees -= EulerY;
        return new Vector2(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad), Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}
