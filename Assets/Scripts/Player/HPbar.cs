using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    Transform hp;

    public void HPbarCurrent(int a) 
    {

        Vector2 get = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta;
        get.x = a *( transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta.x /100);
        transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta = get;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text =  a.ToString();
    }
    private void Start()
    {
        HPbarCurrent(33);
    }
}
