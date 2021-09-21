using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZ10Thousend : MonoBehaviour
{
    [Tooltip("������ �������")]
    public Transform bulletPoolTr;

    [Tooltip("������ �������")]

     public GameObject obgForThousend;

    [Tooltip("�������� �������� �����")]
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
     6. * ������� �� ��������� ����� ������-���������, ������� ������� 10 ����� Empty GameObjects � ����� ������ ����������� (�������), ������� ��� ������ Update ������� ���� ������ ������ ����� ���. 
    ����������������, ������� �� ��� �������� ��������. ���������� � ������ ������������� ������� � ����� ������������.*/
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
