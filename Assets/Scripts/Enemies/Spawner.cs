using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform EnemyPull;
    [SerializeField]
    public Transform SpawnPlace;


    private IEnumerator SpawnDelay(int cont)
    { //while (true)
        yield return new WaitForSeconds(2);
    }

    void Start()
    {
        List<int> closedPointIndex = new List<int>();        

        for (int i = 0; i < EnemyPull.childCount; i++)
        {       
            
            var r = Random.Range(0, SpawnPlace.childCount);
            for (int j = 0; j < closedPointIndex.Count; j++)
            {
                if (closedPointIndex.Contains(r))
                { r = Random.Range(0, SpawnPlace.childCount) ; }
                else break;
            }
            if (closedPointIndex.Count > 10)
            { closedPointIndex.Clear(); }
            var enemyObg = EnemyPull.GetChild(i);
            enemyObg.transform.position = SpawnPlace.GetChild(r).transform.position;
            closedPointIndex.Add(r);
            //closedPointIndex[i] = r;
            enemyObg.GetChild(0).gameObject.SetActive(true);
           // SpawnDelay(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
int[] closedPointIndex = { 0 };

for (int i = 0; i < EnemyPull.childCount; i++)
{

    var r = Random.Range(0, SpawnPlace.childCount);
    for (int j = 0; j < closedPointIndex.Length; j++)
    {
        if (r == closedPointIndex[j])
        { r = Random.Range(0, SpawnPlace.childCount); }
        else break;

    }

    var enemyObg = EnemyPull.GetChild(i);
    enemyObg.transform.position = SpawnPlace.GetChild(r).transform.position;
    closedPointIndex[i] = r;
    enemyObg.gameObject.SetActive(true);
    //SpawnDelay(i);
}
*/
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