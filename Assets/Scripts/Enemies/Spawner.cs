using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform EnemyPull;
    [SerializeField]
    public Transform SpawnPlace;


    void Start()
    {
        int[] closedPointIndex = new int[EnemyPull.childCount];

        for (int i = 0; i < EnemyPull.childCount; i++)
        {       
            
            var r = Random.Range(0, SpawnPlace.childCount);
            for (int j = 0; j < closedPointIndex.Length; i++)
            {
                if (r == closedPointIndex[j])
                { r = Random.Range(0, SpawnPlace.childCount); }
                else break;
            }

            var enemyObg = EnemyPull.GetChild(i);
            enemyObg.transform.position = SpawnPlace.GetChild(r).transform.position;
            closedPointIndex[i] = r;
            enemyObg.gameObject.SetActive(true);            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
 * int[] closedPointIndex = new int[EnemyPull.childCount];

        for (int i = 0; i < EnemyPull.childCount; i++)
        {            
            var r = Random.Range(0, SpawnPlace.childCount ^ closedPointIndex[Random.Range(0, closedPointIndex.Length)]);

            var enemyObg = EnemyPull.GetChild(i);
            enemyObg.transform.position = SpawnPlace.GetChild(r).transform.position;
            closedPointIndex[i] = r;
            enemyObg.gameObject.SetActive(true);            
        }*/