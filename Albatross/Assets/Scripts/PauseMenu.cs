using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pauseObjects;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }
    }

    //Resets the current level
    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void PauseManager()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    //Pauses the game
    public void ShowPaused()
    {
        foreach (GameObject go in pauseObjects)
        {
            go.SetActive(true);
        }
    }

    //Continues the game
    public void HidePaused()
    {
        foreach (GameObject go in pauseObjects)
        {
            go.SetActive(false);
        }
    }

    //Quits to the main menu
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
