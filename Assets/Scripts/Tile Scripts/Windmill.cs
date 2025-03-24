using UnityEngine;

public class Windmill : BuildingEffect
{
    private Tiles_Builder tilesBuilder;

    protected override void OnEnable()
    {
        base.OnEnable();
        tilesBuilder = FindObjectOfType<Tiles_Builder>();  // Keresd meg a Tiles_Builder példányt a jelenetben
        CheckSurroundingTiles();
    }

    // Ez a metódus végigmegy az összes szomszédos mezõn, és ha WheatFieldet talál, bónuszt ad
    private void CheckSurroundingTiles()
    {
        // Iterálunk a 3x3-as területen, ahol a Windmill található
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
                    if (tileType == (int)TileType.WheatField)
                    {
                        // Bónuszt adunk, ha WheatFieldet találunk
                        Debug.Log($"Kezdeti WheatField-t talált a {checkX},{checkY} pozíción!");
                        Income.Instance.food_income += 1;
                    }
                }
            }
        }
    }

    protected override void CheckNewTile(int x, int y, int tileType)
    {
        if (tileType == (int)TileType.WheatField && IsNeighbour(x, y))
        {
            Debug.Log($"Új WheatField a {x},{y} pozíción, bónuszt kapsz!");
            Income.Instance.food_income += 1;
        }
    }
}
