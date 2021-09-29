using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class WhatToDo : MonoBehaviour
{
   int curentIndexItem= 0;

    public bool scipTutor;
    public bool finishTutor;


    void Awake()
    {
        scipTutor= Settings.getScipTutor();
        finishTutor = Settings.getFinishTutor();
        //finishTutor = scipTutor; // изза !отрицания! условие или требует модернизайцию
        scipTutor = finishTutor;
        if (!scipTutor)
        {
            Time.timeScale = 0;
            transform.GetChild(0).gameObject.SetActive(true);
            curentIndexItem++;
        }
        else Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (!scipTutor)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                NextText();
            }
        }
    }

    void NextText()
    {
        if (curentIndexItem < transform.GetChild(0).GetChild(0).childCount)
        {
            transform.GetChild(0).GetChild(0).GetChild(curentIndexItem - 1).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(0).GetChild(curentIndexItem).gameObject.SetActive(true);
            curentIndexItem++;
        }
        else if (curentIndexItem == transform.GetChild(0).GetChild(0).childCount)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            finishTutor = true;
            Time.timeScale = 1;
            curentIndexItem = 0;
            Settings.FinishTutorSet(true);
            scipTutor = finishTutor;
        }
        else curentIndexItem = 0;
    }

}
