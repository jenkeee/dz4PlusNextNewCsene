using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    Transform hp;

    public void HPbarCurrent(int a) 
    {
        //int b = int.Parse((transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta.x).ToString()); // = new Vector2(a, 14)
        Vector2 get = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta;
        get.x = a *(100/ transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta.x);
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text =  a.ToString();
    }
    private void Start()
    {
        HPbarCurrent(50);
    }
}
