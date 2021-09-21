using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // добавим юзинг

public class m_SceneLoader : MonoBehaviour
{
    public GameObject PauseMenu;
    static bool paused = false;

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
        PauseMenu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        paused = true;
    }

}
