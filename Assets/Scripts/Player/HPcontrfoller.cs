using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HPcontrfoller : MonoBehaviour
{
    static int hpMax =100;
    static int HPcurrent;
    [SerializeField] public GameObject BublForLive;
    static GameObject BublForLive2;


    static float timerForLive;
    // Start is called before the first frame update
    void Start()
    {
        HPcurrent = hpMax;
    }



    public static int HPminus(int val)
    {
        if (timerForLive <= 0)
        {
            HPcurrent = HPcurrent - val;
            HPbar.HPbarCurrent(HPcurrent);
            // Debug.Log(HPcurrent);
            timerForLive = 200;
            BublForLive2.SetActive(true);
            return HPcurrent;
        }
        else
        {
 return HPcurrent;         
        }
    }
        

   
    private void Update()
    {
        if (timerForLive > -1)
            timerForLive--;
        else if (HPcurrent <= 0)
            m_SceneLoader.RestartLvl();
        else if (timerForLive <= 0)
            BublForLive2.SetActive(false);


    }
    private void Awake()
    {
        BublForLive2 = BublForLive;
    }
}
