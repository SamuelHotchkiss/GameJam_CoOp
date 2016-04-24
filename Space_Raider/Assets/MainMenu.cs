using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public void TheFunCannotBeHalted()
    {
        SceneManager.LoadScene(2);
    }

    public void InDevelopmentForOverADecade()
    {
        SceneManager.LoadScene(1);
    }

    public void ByeBye()
    {
        Application.Quit();
    }
}
