using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

   private GameController gameController;

    private void Start()
    {
        Screen.SetResolution(800, 600, false);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    public void Resume()
    {
        gameObject.SetActive(false);
        gameController.ResumeGame();
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        gameController.RestartGame();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        Application.Quit();
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

