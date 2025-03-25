using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : BuildingEffect
{
    private Tiles_Builder tilesBuilder;

    protected override void OnEnable()
    {
        base.OnEnable();
        tilesBuilder = FindObjectOfType<Tiles_Builder>();  // Keresd meg a Tiles_Builder példányt a jelenetben
        CheckSurroundingTiles();
    }

    // Ez a metódus végigmegy az összes szomszédos mezõn, és ha Goldmine-t talál, bónuszt ad
    private void CheckSurroundingTiles()
    {
        // Iterálunk a 3x3-as területen, ahol a Goldmine található
        int xPos = Mathf.FloorToInt(transform.position.x);
        int yPos = Mathf.FloorToInt(transform.position.y);

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int checkX = xPos + i;
                int checkY = yPos + j;

                if (checkX >= 0 && checkX < tilesBuilder.Tiles.GetLength(0) && checkY >= 0 && checkY < tilesBuilder.Tiles.GetLength(1))
                {
                    int tileType = tilesBuilder.Tiles[checkX, checkY];
                    if (tileType == (int)TileType.GoldMine)
                    {
                        // Bónuszt adunk, ha WheatFieldet találunk
                        Debug.Log($"Kezdeti GoldMine-t talált a {checkX},{checkY} pozíción!");
                        Income.Instance.gold_income += 2;
                    }
                }
            }
        }
    }

    protected override void CheckNewTile(int x, int y, int tileType)
    {
        if (tileType == (int)TileType.GoldMine && IsNeighbour(x, y))
        {
            Debug.Log($"Új GoldMine a {x},{y} pozíción, bónuszt kapsz!");
            Income.Instance.gold_income += 2;
        }
    }
}
