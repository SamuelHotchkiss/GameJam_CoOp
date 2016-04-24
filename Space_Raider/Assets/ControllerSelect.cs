using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControllerSelect : MonoBehaviour 
{
    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    bool b1, b2, b3, b4; // for which players are playing

	// Use this for initialization
	void Start () 
    {
        b1 = b2 = b3 = b4 = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Joy1_A") && !b1)
        {
            b1 = true;
            p1.text = "READY!";
            PlayerCount.p1 = true;
        }
        if (Input.GetButtonDown("Joy2_A") && !b2)
        {
            b2 = true;
            p2.text = "READY!";
            PlayerCount.p2 = true;
        }
        if (Input.GetButtonDown("Joy3_A") && !b3)
        {
            b3 = true;
            p3.text = "READY!";
            PlayerCount.p3 = true;
        }
        if (Input.GetButtonDown("Joy4_A") && !b4)
        {
            b4 = true;
            p4.text = "READY!";
            PlayerCount.p4 = true;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
