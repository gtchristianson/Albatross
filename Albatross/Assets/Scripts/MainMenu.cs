using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public bool isStart = false;
    public bool isQuit = false;

    void OnMouseUp()
    {
        if(isStart)
        {
            SceneManager.LoadScene(1);
        }

        if(isQuit)
        {
            Application.Quit();
        }
    }
}
