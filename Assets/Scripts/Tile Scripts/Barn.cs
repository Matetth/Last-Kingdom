using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public Tiles_Builder tilesBuilder;
    void Start()
    {
        tilesBuilder = FindObjectOfType<Tiles_Builder>();

        Vector2 barn_position = transform.position;

        int x_position = Mathf.FloorToInt(barn_position.x);
        int y_position = Mathf.FloorToInt(barn_position.y);


        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {

                if (i == 0 && j == 0)
                    continue;

                int neighbourX = x_position + i;
                int neighbourY = y_position + j;

                if (neighbourX >= 0 && neighbourX < tilesBuilder.Tiles.GetLength(0) && neighbourY >= 0 && neighbourY < tilesBuilder.Tiles.GetLength(1))
                {
                    int tileValue = tilesBuilder.Tiles[neighbourX, neighbourY];

                    if (tileValue == 12) //ha Windmill
                    {
                        Debug.Log($"A {neighbourX},{neighbourY} pozíción Windmill van.");

                        Income.Instance.food_income += 5;
                    }
                }
            }
        }
    }
}
