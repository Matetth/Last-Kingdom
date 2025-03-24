using UnityEngine;

public class Barn : BuildingEffect
{
    private Tiles_Builder tilesBuilder;

    protected override void OnEnable()
    {
        base.OnEnable();
        tilesBuilder = FindObjectOfType<Tiles_Builder>();  // Keresd meg a Tiles_Builder p�ld�nyt a jelenetben
        CheckSurroundingTiles();
    }

    // Ez a met�dus v�gigmegy az �sszes szomsz�dos mez�n, �s ha Windmill-t tal�l, b�nuszt ad
    private void CheckSurroundingTiles()
    {
        // Iter�lunk a 5x5-�s ter�leten, ahol a Barn tal�lhat�
        int xPos = Mathf.FloorToInt(transform.position.x);
        int yPos = Mathf.FloorToInt(transform.position.y);

        // Most 2-2 tartom�nyban iter�lunk a szomsz�dos mez�k�n
        for (int i = -2; i <= 2; i++) // Ez lefedi a -2 �s +2 k�z�tti �rt�keket
        {
            for (int j = -2; j <= 2; j++) // Ez lefedi a -2 �s +2 k�z�tti �rt�keket
            {
                int checkX = xPos + i;
                int checkY = yPos + j;

                // Ellen�rizz�k, hogy a koordin�t�k a t�rk�pen bel�l vannak
                if (checkX >= 0 && checkX < tilesBuilder.Tiles.GetLength(0) && checkY >= 0 && checkY < tilesBuilder.Tiles.GetLength(1))
                {
                    int tileType = tilesBuilder.Tiles[checkX, checkY];

                    // Ha tal�lunk Windmill-t, b�nuszt adunk
                    if (tileType == (int)TileType.Windmill)
                    {
                        Debug.Log($"Kezdeti Windmill-t tal�lt a {checkX},{checkY} poz�ci�n!");
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
