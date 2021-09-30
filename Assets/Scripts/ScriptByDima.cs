using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptByDima : MonoBehaviour
{

    public int lives = 5;
    public int health = 100;

    //Panel
    public AudioSource _audio;
    public AudioClip[] sounds;

    public Vector3 StartPos;


    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }        
    }

    public void SetDamage()
    {
        lives--; 
        health = 100;
        transform.position = StartPos;
    }
}
