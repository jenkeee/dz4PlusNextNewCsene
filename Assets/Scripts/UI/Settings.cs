using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Settings : MonoBehaviour
{

   // public bool test;


    [SerializeField]
    public static bool scipTutor; // как тоглер повесить на? //тоглер повесил  public void ScipTutorSet(bool value)

    [SerializeField]
    public static bool finishTutor;

    
    void Awake()
    {/*
        if (transform.CompareTag("setting"))
        {
            DontDestroyOnLoad(transform);
        }*/
        // ScipTutorSet(false);
        //finishTutor = scipTutor;
    }
    public static bool getScipTutor()
    {
        return scipTutor;
    }

    public static void ScipTutorSet(bool value)
    {
        if (value == true)
        {
            scipTutor = true;
        }
        else
        {
            scipTutor = false; //у нас дальше в коде отрицание, поэтому tut false  
        }
    }
    public static bool getFinishTutor()
    {
        return finishTutor;
    }

    public static void FinishTutorSet(bool value)
    {
        if (value == true)
        {
            finishTutor = true;
        }
        else
        {
            finishTutor = false; 
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
         Debug.Log(scipTutor);
        }
     */
    }
}
