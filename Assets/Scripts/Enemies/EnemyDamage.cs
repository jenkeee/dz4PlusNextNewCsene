using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int dmg;
 
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.collider.CompareTag("Player"))
            {
            Debug.Log("���� ����� ������");
                                HPcontrfoller.HPminus(dmg);

                // � ��� ����� ��� ��������� � ����� ���� ��� ���/ ��� ������� ������, ��� ������ ������ - ������������� ������� ������� ������ � ������ �����
                //StartCoroutine(Untachibl(2000));
                // whoDamaget.GetComponent<SphereCollider>().enabled = true;
                //   whoDamaget.GetComponent<CapsuleCollider>().enabled = true;
            }
             
    }
}

