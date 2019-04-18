using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    Logger player;
    bool initial_logging_state;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Logger>();
        initial_logging_state = player.logging;
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (paused)
        {
            PauseUI.SetActive(true);
            if (initial_logging_state)
            {
                player.logging = false;
                //player.LogPause();
            }
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            if (initial_logging_state)
            {
                player.logging = true;
            }
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
    }
}
