using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Tiles_Builder : MonoBehaviour
{
    public Camera mainCamera;

    private int[,] Tiles = new int[21, 21];

    public GameObject Desert_tile;
    public GameObject Grass_tile;
    public GameObject Water_tile;
    public GameObject WheatField_building;
    public GameObject Windmill_building;
    public GameObject Barn_building;
    public GameObject Fish_building;

    public GameObject Tiles_UI;
    public GameObject Buildings_UI;

    private int x_position;
    private int y_position;

    private int remaining_tiles = 3;

    public bool Desert_Selected = false;
    public bool Grass_Selected = false;
    public bool Water_Selected = false;

    public bool WheatField_Selected = false;
    public bool Windmill_Selected = false;
    public bool Barn_Selected = false;
    public bool Fish_Selected = false;

    private Vector2 Placer;

    private void Start()
    {
        for (int i = 9; i < 12; i++)
        {
            for (int j = 9; j < 12; j++)
            {
                Tiles[i, j] = 2; //A füves csempék kódja a 2-es
            }
        }
        Tiles[10, 10] = 100; // Ez a város (100-as kód)
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mouseScreenPosition = Input.mousePosition;
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            x_position = Convert.ToInt32(mouseWorldPosition.x);
            y_position = Convert.ToInt32(mouseWorldPosition.y);

            Placer.x = x_position;
            Placer.y = y_position;

            TileDecider();
        }
        
    }

    public void TileDecider()
    {
        if ((0 <= x_position && x_position <= 20) && (0 <= y_position && y_position <= 20))
        {
            if (remaining_tiles > 0 && Tiles[x_position, y_position] == 0)
            {
                if (Desert_Selected == true)
                {
                    PlaceTile(Desert_tile, 1, ref Desert_Selected, x_position, y_position);
                    remaining_tiles--;
                }
                else if (Grass_Selected == true)
                {
                    PlaceTile(Grass_tile, 2, ref Grass_Selected, x_position, y_position);
                    remaining_tiles--;
                }
                else if (Water_Selected == true)
                {
                    PlaceTile(Water_tile, 3, ref Water_Selected, x_position, y_position);
                    remaining_tiles--;
                }
            }
            else if (remaining_tiles == 0)
            {
                Tiles_UI.SetActive(false);
                Buildings_UI.SetActive(true);
            }

            if(remaining_tiles == 0 && Tiles[x_position, y_position] == 2)
            {
                if (WheatField_Selected == true)
                {
                    PlaceTile(WheatField_building, 11, ref WheatField_Selected, x_position, y_position);
                }
                else if (Windmill_Selected == true)
                {
                    PlaceTile(Windmill_building, 12, ref Windmill_Selected, x_position, y_position);
                }
                else if (Barn_Selected == true)
                {
                    PlaceTile(Barn_building, 13, ref Barn_Selected, x_position, y_position);
                }
            }

            if(remaining_tiles == 0 && Tiles[x_position, y_position] == 3)
            {
                if (Fish_Selected == true)
                {
                    PlaceTile(Fish_building, 14, ref Fish_Selected, x_position, y_position);
                }
            }
        }
        
    }

    void PlaceTile(GameObject tilePrefab, int tileType, ref bool tileSelected, int x_position, int y_position)
    {
        GameObject newObject = Instantiate(tilePrefab, Placer, Quaternion.identity);
        tileSelected = false;
        Tiles[x_position, y_position] = tileType;
        Debug.Log(x_position + " " + y_position);
    }

    void SelectTileType(ref bool selectedTile, ref bool otherTile1, ref bool otherTile2)
    {
        if (selectedTile == true)
        {
            selectedTile = false;
        }
        else
        {
            selectedTile = true;
            otherTile1 = false;
            otherTile2 = false;
        }
    }

    void SelectTileType(ref bool selectedTile, ref bool otherTile1, ref bool otherTile2, ref bool otherTile3)
    {
        if (selectedTile == true)
        {
            selectedTile = false;
        }
        else
        {
            selectedTile = true;
            otherTile1 = false;
            otherTile2 = false;
            otherTile3 = false;
        }
    }

    public void SelectDesert()
    {
        SelectTileType(ref Desert_Selected, ref Grass_Selected, ref Water_Selected);
    }

    public void SelectGrass()
    {
        SelectTileType(ref Grass_Selected, ref Desert_Selected, ref Water_Selected);
    }

    public void SelectWater()
    {
        SelectTileType(ref Water_Selected, ref Desert_Selected, ref Grass_Selected);
    }

    public void SelectWheatField()
    {
        SelectTileType(ref WheatField_Selected, ref Windmill_Selected, ref Barn_Selected, ref Fish_Selected);
    }

    public void SelectWindmill()
    {
        SelectTileType(ref Windmill_Selected, ref WheatField_Selected, ref Barn_Selected, ref Fish_Selected);
    }

    public void SelectBarn()
    {
        SelectTileType(ref Barn_Selected, ref WheatField_Selected, ref Windmill_Selected, ref Fish_Selected);
    }

    public void SelectFish()
    {
        SelectTileType(ref Fish_Selected, ref WheatField_Selected, ref Windmill_Selected, ref Barn_Selected);
    }
}
