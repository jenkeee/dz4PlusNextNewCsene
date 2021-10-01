using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZ10Thousend : MonoBehaviour
{
    [Tooltip("Объект обертка")]
    public Transform bulletPoolTr;

    [Tooltip("префаб объекта")]

     public GameObject obgForThousend;

    [Tooltip("скорость вращения кубов")]
    [SerializeField]
    float y = 0.1f;
    float x;
    float z;

    int maxObg = 10000;
    //next possition   
    int nextX = -14;
    int nextY = 0;
    int nextZ = -14;



    /*
     6. * Сделать на отдельной сцене скрипт-генератор, который создаст 10 тысяч Empty GameObjects с одним пустым компонентом (классом), который при каждом Update вращает этот объект вокруг своей оси. 
    Проанализировать, сколько на это тратится ресурсов. Отпишитесь в тексте практического задания о вашем эксперименте.*/
    void Start()
    {        
        int xUp = 0;
        for (int i =0; i < maxObg;i++) 
            
        {
            if (i % 100 == 0)
            {
                nextZ++; xUp = 0;
            }
            GameObject thousend = Instantiate(obgForThousend, new Vector3(nextX + xUp, nextY, nextZ), Quaternion.identity, bulletPoolTr);
            thousend.name = $"newCube{i}";
            xUp++;            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxObg; i++)
        {            
            bulletPoolTr.GetChild(i).Rotate(new Vector3(Time.deltaTime * x, y, z));
        }
    }
}
