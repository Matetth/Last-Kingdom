using UnityEngine;

public class Income : MonoBehaviour
{
    public TMPro.TMP_Text food_count_text;
    public TMPro.TMP_Text population_count_text;
    public TMPro.TMP_Text food_income_text;
    public TMPro.TMP_Text population_income_text;

    public int food_count = 0;
    public int population_count = 0;
    public int food_income = 0;
    public int population_income = 0;

    void Update()
    {
        food_count_text.text = food_count.ToString();
        population_count_text.text = population_count.ToString();

        if (food_income >= 0)
        {
            food_income_text.text = "+" + food_income.ToString();
        }
        else if (food_income < 0)
        {
            food_income_text.text = food_income.ToString();
        }

        if (population_income >= 0)
        {
            population_income_text.text = "+" + population_income.ToString();
        }
        else if(population_income < 0)
        {
            population_income_text.text = population_income.ToString();
        }
    }
}
