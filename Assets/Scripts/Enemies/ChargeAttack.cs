using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ChargeAttack : MonoBehaviour
{
    /*

    public Transform player;
    NavMeshAgent agent;

    static bool ReadyAtk;
    
    [SerializeField] private float maxAngle = 30;
    [SerializeField] private float maxRadius = 20;
    [SerializeField] private float chargeDistance = 20;

    Rigidbody RBenemy;
    int delayBetwenAttack = 100;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RBenemy = GetComponent<Rigidbody>();
        PlayerDisDetected();
    }



    void FixedUpdate()
    { }
    void LateUpdate() { }
    void Update()
    {
        if (ReadyAtk)
        {
            Vector3 napravlenieVzglad = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(napravlenieVzglad);
            //agent.stoppingDistance = 0;
            agent.stoppingDistance = maxRadius;
            if (napravlenieVzglad.magnitude > chargeDistance + 1)
            {
                
                    RBenemy.isKinematic = true;
                    agent.isStopped = false;
                    agent.SetDestination(player.position);
                    //RBenemy.MovePosition(-napravlenieVzglad);
                   // Debug.Log("вижу иду");
                
            }
         
            else if (napravlenieVzglad.magnitude < chargeDistance - 1 && napravlenieVzglad.magnitude > 0 )
            {
                delayBetwenAttack--;
                agent.isStopped = false;
                //RBenemy.isKinematic = true;
                
               // Debug.Log("вижу отхожу");
                agent.SetDestination( transform.position - transform.forward*30);
                
            }
             else if (napravlenieVzglad.magnitude > chargeDistance - 1  && napravlenieVzglad.magnitude < chargeDistance + 1)
             {

                 delayBetwenAttack--;
                 agent.isStopped = true;
                 //Debug.Log("готов атаковать");

                 if (delayBetwenAttack <= 0)
                 {
                     RBenemy.isKinematic = false;
                     Attack();
                 }

             }
        }

    }
    
          private  void Attack()
    {
        RBenemy.velocity = Vector3.zero;
        RBenemy.freezeRotation = true;
        Debug.Log("чардж");
        RBenemy.AddForce(gameObject.transform.forward * 30, ForceMode.Impulse); //  gameObject.transform.up*30 не работает
        delayBetwenAttack = 200;
    }
    public static void PlayerDetected()
    {
        ReadyAtk = true;
    }
    public static void PlayerDisDetected()
    {
        ReadyAtk = false;
    }
    */
}
