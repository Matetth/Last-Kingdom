using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : BuildingEffect
{
    private Tiles_Builder tilesBuilder;

    protected override void OnEnable()
    {
        base.OnEnable();
        tilesBuilder = FindObjectOfType<Tiles_Builder>();  // Keresd meg a Tiles_Builder p�ld�nyt a jelenetben
        CheckSurroundingTiles();
    }

    // Ez a met�dus v�gigmegy az �sszes szomsz�dos mez�n, �s ha Houses-t tal�l, b�nuszt ad
    private void CheckSurroundingTiles()
    {
        // Iter�lunk a 3x3-as ter�leten, ahol a Houses tal�lhat�
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
                    if (tileType == (int)TileType.Houses)
                    {
                        // B�nuszt adunk, ha Houses-t tal�lunk
                        Debug.Log($"Kezdeti Houses-t tal�lt a {checkX},{checkY} poz�ci�n!");
                        Income.Instance.gold_income += 1;
                    }
                }
            }
        }
    }

    protected override void CheckNewTile(int x, int y, int tileType)
    {
        if (tileType == (int)TileType.Houses && IsNeighbour(x, y))
        {
            Debug.Log($"�j Houses a {x},{y} poz�ci�n, b�nuszt kapsz!");
            Income.Instance.gold_income += 1;
        }
    }
}
