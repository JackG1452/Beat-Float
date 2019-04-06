using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject countDown;
    public AudioSource music;
    public void PauseFunc()
    {
     
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        
    }
    public void Resume()
    {
        music.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = (false);
        PlatformSpawner.instance.enabled = true;
        //countDown.SetActive(true);

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = (true);
        PlatformSpawner.instance.enabled = false;
        //countDown.SetActive(false);
        music.Pause();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
