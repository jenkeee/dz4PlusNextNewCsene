using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    static Transform hp;

    public static void HPbarCurrent(int a) 
    {

        Vector2 get = hp.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta;
        get.x = a *(hp.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta.x /100);        
        hp.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta = get;
        if (get.x > 0)
            hp.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = a.ToString();
        else hp.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "0";
    }
    private void Start()
    {
        hp = transform;
        //HPbarCurrent(33);
    }
}
