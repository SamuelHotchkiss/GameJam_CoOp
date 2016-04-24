using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public GameObject[] players = new GameObject[4];
    int playerCount;

    public GameObject youSuck;
    public GameObject youWin;

    bool gameOver = false;

	void Start () 
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        //playerCount = players.Length;
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

    void OnLevelWasLoaded(int level)
    {
        if (PlayerCount.p1)
        {
            players[0].SetActive(true);
            playerCount++;
        }
        if (PlayerCount.p2)
        {
            players[1].SetActive(true);
            playerCount++;
        }
        if (PlayerCount.p3)
        {
            players[2].SetActive(true);
            playerCount++;
        }
        if (PlayerCount.p4)
        {
            players[3].SetActive(true);
            playerCount++;
        }
    }
}
