using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // добавим юзинг

public class m_SceneLoader : MonoBehaviour
{
    public AudioSource audio;
    public GameObject PauseMenu;
    public bool paused = false;





    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }


    public void QuitGame() { Application.Quit(); }

    public void Thousend10lvl()
    { 
        SceneManager.LoadScene("Thousend10lvl");
    }

    public void MenuMain() { SceneManager.LoadScene("MainMenu"); }

    public void Continue() {
        Resume();       
    }

    private void Start()
    {if (PauseMenu != null)
        PauseMenu.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name !="MainMenu")
        {
            if (paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }
    void Pause()
    {
        Time.timeScale = 0;
       // SceneManager.SetActiveScene()
        PauseMenu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        paused = true;
    }

    public void SettingMenu()
    {
                transform.parent.Find("SettingMenu").gameObject.SetActive(true);
       // transform.gameObject.SetActive(false);// выключаем родителя не особо надо
        
    }
    public void Back()
    {// сразу с заделом на будещее

        
        for (int i = 0; i < transform.parent.childCount; i++)
        { transform.parent.GetChild(i).gameObject.SetActive(false); }

        transform.parent.Find("MainMenu").gameObject.SetActive(true);

    }

    /*
    void OnDisable()
    {
        DontDestroyOnLoad(audio);
        audio.mute = false;
    }
    private void Awake()
    {
        DontDestroyOnLoad(audio);
        audio.mute = false;
    }*/
    
    void Awake()
    {

        if (this.CompareTag("music"))
            {
            DontDestroyOnLoad(this);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      /* if (scene.name == "3")
            audio.mute = true;
        else*/
            audio.mute = false;
    }

    void Destroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


