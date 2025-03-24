using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //Játék megállításhoz és referálások
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    void Pause()
    {
        //Játék és idõ megállítása, menü behozása
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        //Játék és idõelindítás, menü eltüntetése
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }


    void Update()
    {
        //Ha lenyomjuk a Escape gombot
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //És a játék éppen megy
            if (GameIsPaused == false)
            {
                //A játék álljon meg
                Pause();
            }
            //Ellenkezõ esetben menjen tovább
            else
            {
                Resume();
            }
        }
    }

    //Kilépés a fõmenübe
    public void ExitToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
