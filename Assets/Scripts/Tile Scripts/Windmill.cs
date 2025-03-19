using UnityEngine;

public class Windmill : MonoBehaviour
{
    public Tiles_Builder tilesBuilder;
    void Start()
    {
        tilesBuilder = FindObjectOfType<Tiles_Builder>();

        Vector2 windmill_position = transform.position;

        int x_position = Mathf.FloorToInt(windmill_position.x);
        int y_position = Mathf.FloorToInt(windmill_position.y);


        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                
                if (i == 0 && j == 0)
                continue;

                int neighbourX = x_position + i;
                int neighbourY = y_position + j;

                if (neighbourX >= 0 && neighbourX < tilesBuilder.Tiles.GetLength(0) && neighbourY >= 0 && neighbourY < tilesBuilder.Tiles.GetLength(1))
                {
                    int tileValue = tilesBuilder.Tiles[neighbourX, neighbourY];

                    if (tileValue == 11)
                    {
                        Debug.Log($"A {neighbourX},{neighbourY} pozíción WheatField van.");

                        Income.Instance.food_income += 1;
                    }
                }
            }
        }
    }
}
