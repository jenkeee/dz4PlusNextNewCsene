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
        stringToEdit = "\n\t������, ����� ���������� � ������. \n\t�� ������ ������ ������ ��� ��� �������. \n\t���� ������� �������� �� �������.\n\t � ������� ��������.";        
    }

    void OnGUI()
    {
       GUI.TextArea((new Rect(Screen.width/2-300, Screen.height/2-200, 600, 400)), stringToEdit);
        GUI.TextField((new Rect(Screen.width / 2 - "��� ����������� ����� Enter".Length, Screen.height - 20, 200, 20)), "��� ����������� ����� Enter");

    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            stringToEdit = "\n\t���� ����� ������� ��������� ������� � ����� ������, ���� �����. \n\t��� �� ����� ����� ����� ������ ������ � �������";
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                stringToEdit = "\n\t�� ������ ���� ������� ����� �� ��� ���� ������� ������� 10 �������� � �����.";
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    stringToEdit = "�� ��� � ���. � ���� ! ����� �� ��� ��� ������ enter ���� ���������� ";
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
