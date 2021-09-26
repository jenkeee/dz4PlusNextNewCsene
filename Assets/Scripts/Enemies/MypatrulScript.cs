using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MypatrulScript : MonoBehaviour
{

    public Transform WaitPlace;
    NavMeshAgent agent;
    Rigidbody RBenemy;

    public bool patrulMode;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask targetObstacl;
    [SerializeField] private Collider[] targetViewRadius;
    [SerializeField] private Collider[] targetViewFrontAngle;

    float maxRadius=10f;
    [SerializeField] private float maxAngle = 30;
    //[SerializeField] float alpha_gizmosSpere =0.1f;
    void Start()
    {
        //WaitPlace = FindObjectOfType<Spawner>().gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        RBenemy = GetComponent<Rigidbody>();
        agent.SetDestination(WaitPlace.GetChild(Random.Range(0, WaitPlace.childCount)).transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrulMode)
        {
            RBenemy.isKinematic = true;
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(WaitPlace.GetChild(Random.Range(0, WaitPlace.childCount)).transform.position);
            }
        }
        else { agent.isStopped = true; }


    }
    IEnumerator Scaning(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            agent.isStopped = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 360, 0), Time.deltaTime);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1, 0, 1, 0.08f);
        Handles.DrawSolidArc(gameObject.transform.position, transform.up, transform.forward, 360, maxRadius);
        Handles.DrawSolidArc(gameObject.transform.position, transform.up, transform.forward, maxAngle, maxRadius* (2 + 1 / 2));
        Handles.DrawSolidArc(gameObject.transform.position, transform.up, transform.forward, -maxAngle, maxRadius* (2 + 1 / 2));
    }
#endif
    private void FixedUpdate()
    {
        targetViewRadius = Physics.OverlapSphere(transform.position, maxRadius, targetMask); // targetViewRadius в данном случае это масив колайдеров и мы получим каждый вошедший колайдер
                                                                                             // на маске в радиусе который мы указали
        targetViewFrontAngle = Physics.OverlapSphere(transform.position, maxRadius*(2+1/2), targetMask);
       // targetViewFrontAngle = Physics.OverlapSphere(transform.position, maxRadius * (2 + 1 / 2), targetObstacl);
        if (targetViewRadius.Length > 0)
        {
            agent.isStopped = true;
            patrulMode = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetViewRadius[0].transform.position - transform.position), Time.deltaTime);
        }

        else if (targetViewFrontAngle.Length > 0) // сначала  OverlapSphere меньшего радиуса инче не работает
        {
            agent.isStopped = false;
            patrulMode = true;
            for (int i = 0; i < targetViewFrontAngle.Length -1 ; i++)
            {
                Transform tempTarget = targetViewFrontAngle[i].transform;
                Vector3 dirToTarget = (tempTarget.position - transform.position).normalized;
                float targetAngle = Vector3.Angle(transform.forward, dirToTarget);

                Ray ray = new Ray(transform.position, dirToTarget);
                RaycastHit raycastHit;
                if (!Physics.Raycast(transform.position + Vector3.up, dirToTarget, targetObstacl))
                {
                    if ((-maxAngle) < targetAngle && targetAngle < maxAngle)
                    {
                        Debug.DrawRay(transform.position + Vector3.up, dirToTarget * maxRadius * 2, Color.red);
                        agent.isStopped = true;
                        patrulMode = false;
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetViewFrontAngle[i].transform.position - transform.position), Time.deltaTime);
                        // буду через маску обсткл делать проверку. чето все не так

                        if (Physics.Raycast(transform.position, dirToTarget, out raycastHit))
                        {
                            if (raycastHit.collider.CompareTag("Player"))
                            {

                            }
                        }
                    }
                }
            }
        }
        
        else 
        { //StartCoroutine(Scaning(5));
            agent.isStopped = false;
            patrulMode = true;
            //ChargeAttack.PlayerDisDetected();
        }
    }

    public void PatrulEnable() { patrulMode = true; }
    public void PatrulDisable() { patrulMode = false; }
}
