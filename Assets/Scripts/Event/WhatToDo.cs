using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WhatToDo : MonoBehaviour
{

    string asd;

    public string stringToEdit;




    void Awake()
    {
            Time.timeScale = 0;
        stringToEdit = "\n\tПривет, добро пожаловать в москву. \n\tТы видешь старую москву она как воронеж. \n\tТебе следует пройтись по локации.\n\t И собрать гопников.";        
    }

    void OnGUI()
    {
       GUI.TextArea((new Rect(Screen.width/2-300, Screen.height/2-200, 600, 400)), stringToEdit);
        GUI.TextField((new Rect(Screen.width / 2 - "для продолжения нажми Enter".Length, Screen.height - 20, 200, 20)), "для продолжения нажми Enter");

    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            stringToEdit = "\n\tЕсли вдруг красные перестали пердеть и стали гореть, будь готов. \n\tЭто то самое время когда пацана заехал в стройку";
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                stringToEdit = "\n\tНа уровне тебе следует найти то что тебе поможет загнать 10 гопников в ларек.";
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    stringToEdit = "Ну вот и все. В путь ! когда ты еще раз нажмеш enter игра запустится ";
                    if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                    {
                        Time.timeScale = 1;
                        stringToEdit.Remove(0);
                    }
                }
            }
        }
    }


}
