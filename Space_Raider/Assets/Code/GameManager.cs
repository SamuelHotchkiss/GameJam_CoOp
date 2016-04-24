using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public GameObject[] players;
    int playerCount;

    public GameObject youSuck;
    public GameObject youWin;

    bool gameOver = false;

	void Start () 
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = players.Length;
	}
	
	void Update () 
    {
	    if (gameOver)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(0);
        }
	}

    public void PlayerDied()
    {
        playerCount--;
        if (playerCount <= 0)
        {
            youSuck.SetActive(true);
            gameOver = true;
        }
    }

    public void BossDied()
    {
        youWin.SetActive(true);
        gameOver = true;
    }
}
