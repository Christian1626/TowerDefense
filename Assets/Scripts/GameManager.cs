using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;
    public static bool GameIsOver;

    void Start() {
        GameIsOver = false;
    }

    //check la vie du joueur
	void Update () {

        if (Input.GetKeyDown("e"))
            EndGame();
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        Debug.Log("ENDGAME");
        GameIsOver = true;
        Debug.Log("Game Over!");

        gameOverUI.SetActive(true);
    }
}
