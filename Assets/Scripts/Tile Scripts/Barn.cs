using UnityEngine;

public class Barn : BuildingEffect
{
    private Tiles_Builder tilesBuilder;

    protected override void OnEnable()
    {
        base.OnEnable();
        tilesBuilder = FindObjectOfType<Tiles_Builder>();  // Keresd meg a Tiles_Builder példányt a jelenetben
        CheckSurroundingTiles();
    }

    // Ez a metódus végigmegy az összes szomszédos mezõn, és ha Windmill-t talál, bónuszt ad
    private void CheckSurroundingTiles()
    {
        // Iterálunk a 5x5-ös területen, ahol a Barn található
        int xPos = Mathf.FloorToInt(transform.position.x);
        int yPos = Mathf.FloorToInt(transform.position.y);

        // Most 2-2 tartományban iterálunk a szomszédos mezõkön
        for (int i = -2; i <= 2; i++) // Ez lefedi a -2 és +2 közötti értékeket
        {
            for (int j = -2; j <= 2; j++) // Ez lefedi a -2 és +2 közötti értékeket
            {
                int checkX = xPos + i;
                int checkY = yPos + j;

                // Ellenõrizzük, hogy a koordináták a térképen belül vannak
                if (checkX >= 0 && checkX < tilesBuilder.Tiles.GetLength(0) && checkY >= 0 && checkY < tilesBuilder.Tiles.GetLength(1))
                {
                    int tileType = tilesBuilder.Tiles[checkX, checkY];

                    // Ha találunk Windmill-t, bónuszt adunk
                    if (tileType == (int)TileType.Windmill)
                    {
                        Debug.Log($"Kezdeti Windmill-t talált a {checkX},{checkY} pozíción!");
                        Income.Instance.food_income += 5;
                    }
                }
            }
        }
    }


    protected override void CheckNewTile(int x, int y, int tileType)
    {
        if (tileType == (int)TileType.Windmill && IsNeighbour(x, y))
        {
            Debug.Log($"Found Windmill at {x},{y}, applying bonus.");
            Income.Instance.food_income += 5;
        }
    }


}
