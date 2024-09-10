using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu_Script : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
}
