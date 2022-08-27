using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame ()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void Credits ()
    {
        SceneManager.LoadScene(5);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
