using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int phasecounter = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}