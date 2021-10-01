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
            Debug.Log("враг задел игрока");
                                HPcontrfoller.HPminus(dmg);

                // я щас думаю как привязать к ригит бади это все/ чем сильней боднул, тем дальше отлете - соотвественно получил больнее значит и больше урона
                //StartCoroutine(Untachibl(2000));
                // whoDamaget.GetComponent<SphereCollider>().enabled = true;
                //   whoDamaget.GetComponent<CapsuleCollider>().enabled = true;
            }
             
    }
}

