using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float Radius;
    [Range(0,360)] 
    public float Angle;
    public GameObject Player;
    public LayerMask TargetMask;
    public LayerMask ObstructionMask;
    public bool CanSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Routine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Routine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FovCheck();
        }
    }

    public void FovCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 DirectionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, DirectionToTarget) < Angle / 2)
            {
                float DistanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, DirectionToTarget, DistanceToTarget, ObstructionMask))
                    CanSeePlayer = true;
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer)
            CanSeePlayer = false;
    }
}