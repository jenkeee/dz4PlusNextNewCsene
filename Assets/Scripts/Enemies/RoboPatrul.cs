using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoboPatrul : MonoBehaviour
{

    [SerializeField]
    public Transform WaitPlace;
    NavMeshAgent agent;

    List<int> closedPointIndex;

    public Animator _animator;
    public bool move;

    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
       // List<int> closedPointIndex = new List<int>();
        agent = GetComponent<NavMeshAgent>();
        if (agent.SetDestination(WaitPlace.GetChild(Random.Range(0, WaitPlace.childCount)).transform.position))
        {
            _animator.SetBool("GoToRoll", true);
        }
       /* для блокировки мест где был*/      
       /*
        for (int i = 0; i < WaitPlace.childCount; i++)
        {       
            
            var r = Random.Range(0, WaitPlace.childCount);
            for (int j = 0; j < closedPointIndex.Count-1; j++)
            {
                if (closedPointIndex.Contains(r))
                { r = Random.Range(0, WaitPlace.childCount) ; }
                else break;
            }
            if (closedPointIndex.Count > 10)
            { closedPointIndex.Clear(); }
            var enemyObg = WaitPlace.GetChild(i);
            enemyObg.transform.position = WaitPlace.GetChild(r).transform.position;
            closedPointIndex.Add(r);
           
            enemyObg.gameObject.SetActive(true);
          
        }*/
    }

    IEnumerator WaitingOnPoint(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                if (agent.SetDestination(WaitPlace.GetChild(Random.Range(0, WaitPlace.childCount)).transform.position)) _animator.SetBool("GoToRoll", true);
                StopCoroutine( WaitingOnPoint(2));
            }
        }
    }
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            _animator.SetBool("GoToRoll", false);
            StartCoroutine(WaitingOnPoint(2));
        }
        else if (agent.remainingDistance > agent.stoppingDistance)
        {
            _animator.SetBool("GoToRoll", true);
        }
    }
}