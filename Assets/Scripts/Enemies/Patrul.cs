using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Patrul : MonoBehaviour
{/*
    [Tooltip("масив вейпоинтов")]
    public Transform wayPoints;
    [SerializeField] public static bool modePatrul;
    public Transform[] playerAndFriends;


    [SerializeField] private float maxAngle = 30;
    [SerializeField] private float maxRadius = 20;


    //для OverlapSphere и цикла for для ray в нем
    [SerializeField] private Collider[] targetViewRadius;
    [SerializeField] private List<Transform> visibleTargets = new List<Transform>();
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstaklMask;
    NavMeshAgent agent;
    Rigidbody RBenemy;


/*
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position + Vector3.up;
        Handles.color = new Color(1, 0, 1, 0.1f);
        Handles.DrawSolidArc(pos, transform.up, transform.forward, maxAngle, maxRadius);
        Handles.DrawSolidArc(pos, transform.up, transform.forward, -maxAngle, maxRadius);

    }
#endif

    void Start()
    {
        modePatrul = true;
        agent = GetComponent<NavMeshAgent>();
        RBenemy = GetComponent<Rigidbody>();
        agent.SetDestination(wayPoints.GetChild(Random.Range(0, wayPoints.childCount - 1)).position);
        RBenemy.isKinematic = true;
        // StartCoroutine(FindTargets(0.1f));
    }
    
    IEnumerator FindTargets(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }
    private void FindVisibleTarget()
    {
        targetViewRadius = Physics.OverlapSphere(transform.position, maxRadius, targetMask);
        for (int i = 0; i < targetViewRadius.Length; i++)
        {
            Transform tempTarget = targetViewRadius[i].transform;
            Vector3 dirToTarget = (tempTarget.position - transform.position).normalized;
            float targetAngle = Vector3.Angle(transform.forward, dirToTarget);

            if ((-maxAngle) < targetAngle && targetAngle < maxAngle)
            {
                Debug.DrawRay(transform.position + Vector3.up, dirToTarget * maxRadius, Color.red);
                if (!Physics.Raycast(transform.position + Vector3.up, dirToTarget, obstaklMask))
                {
                    if (!visibleTargets.Contains(tempTarget))
                    {
                        visibleTargets.Add(tempTarget);
                        ChargeAttack.PlayerDetected();
                    }
                }
            }
        }
    }
    public static void PatrulOn()
    { modePatrul = true; }
    public static void PatrulOff()
    { modePatrul = false; }
    void Update()
    {
        if (false)
        {
            //StopCoroutine(FindTargets(0.1f));
            RBenemy.isKinematic = true;
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(wayPoints.GetChild(Random.Range(0, wayPoints.childCount - 1)).position);
            }
            //else if (Physics.Raycast(transform.position + Vector3.up, maxRadius, targetMask))
        }
       
        /*
        targetViewRadius = Physics.OverlapSphere(transform.position, maxRadius, targetMask);
        for (int i = 0; i < targetViewRadius.Length; i++)
        {
            Transform tempTarget = targetViewRadius[i].transform;
            Vector3 dirToTarget = (tempTarget.position - transform.position).normalized;
            float targetAngle = Vector3.Angle(transform.forward, dirToTarget);            

            Ray ray = new Ray(transform.position, dirToTarget);
            RaycastHit raycastHit;

            if ((-maxAngle) < targetAngle && targetAngle < maxAngle)
            {
                Debug.DrawRay(transform.position + Vector3.up, dirToTarget * maxRadius, Color.red);
                ChargeAttack.PlayerDetected();
                if (Physics.Raycast(transform.position, dirToTarget, out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("Player") ^ raycastHit.collider.CompareTag("Enemy"))
                    {
                        ChargeAttack.PlayerDetected();
                        Debug.Log("Попадание");
                    }
                }
                
                
            }
        }
   }*/
}
