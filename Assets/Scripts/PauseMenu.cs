using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public GameObject ui;
    public SceneFader sceneFader;

	void Update()
    {
        if (GameManager.GameIsOver)
            return;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        //freeze le jeu
        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo("MenuScene");
        Debug.Log("Go To Menu");
    }
    
    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
