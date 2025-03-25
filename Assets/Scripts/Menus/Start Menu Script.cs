using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu_Script : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quiting...");
    }
}
