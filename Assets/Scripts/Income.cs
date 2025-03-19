using UnityEngine;

public class Income : MonoBehaviour
{
    public static Income Instance;

    public TMPro.TMP_Text food_count_text;
    public TMPro.TMP_Text population_count_text;
    public TMPro.TMP_Text food_income_text;
    public TMPro.TMP_Text population_income_text;

    public int food_count = 0;
    public int population_count = 0;
    public int food_income = 0;
    public int population_income = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        food_count_text.text = food_count.ToString();
        population_count_text.text = population_count.ToString();

        if (food_income >= 0)
        {
            food_income_text.text = "+" + food_income.ToString();
            food_income_text.color = new Color32(0, 150, 0, 255); //zöld
        }
        else if (food_income < 0)
        {
            food_income_text.text = food_income.ToString();
            food_income_text.color = new Color32(150, 0, 0, 255); //piros
        }

        if (population_income >= 0)
        {
            population_income_text.text = "+" + population_income.ToString();
            food_income_text.color = new Color32 (0, 150, 0, 255); //zöld
        }
        else if(population_income < 0)
        {
            population_income_text.text = population_income.ToString();
            food_income_text.color = new Color32(150, 0, 0, 255); //piros
        }
    }
}
