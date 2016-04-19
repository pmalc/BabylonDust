using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    //Main Menu
    public void newGame()
    {
        SceneManager.LoadScene(3);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("");
    }

    public void options()
    {
        SceneManager.LoadScene(4);
    }

    public void credits()
    {
        SceneManager.LoadScene("");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    //Options Menu
    public void controls()
    {
        SceneManager.LoadScene(5);
    }

    public void screen()
    {
        SceneManager.LoadScene("");
    }

    public void sound()
    {
        SceneManager.LoadScene("");
    }

    public void exitOptions()
    {
        SceneManager.LoadScene(2);
    }
    public void exitControls()
    {
        SceneManager.LoadScene(4);
    }
}
