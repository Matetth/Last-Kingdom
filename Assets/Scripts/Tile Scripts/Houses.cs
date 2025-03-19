using UnityEngine;

public class Houses : MonoBehaviour
{
    void Start()
    {
        if (Income.Instance != null)
        {
            Income.Instance.population_income += 1;
        }
        else
        {
            Debug.LogError("Income nem található!");
        }
    }

}
