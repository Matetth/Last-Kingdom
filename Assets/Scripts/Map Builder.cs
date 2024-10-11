using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Map_Builder : MonoBehaviour
{
    public Camera mainCamera;

    public int[,] Tiles = new int[21, 21];
    public GameObject Desert_tile;
    public GameObject Grass_tile;
    public GameObject Water_tile;

    public int x_position;
    public int y_position;
    public int remaining_tiles = 0;

    public bool Desert_Selected = false;
    public bool Grass_Selected = false;
    public bool Water_Selected = false;

    public Vector2 Placer;

    private void Start()
    {
        //Tiles = new int[21, 21];
        for (int i = 9; i < 12; i++)
        {
            for (int j = 9; j < 12; j++)
            {
                Tiles[i, j] = 1;
            }
        }
        Tiles[10, 10] = 100; //Ez fixen a város (100-as kód)
    }

    void Update()
    {
        if (remaining_tiles > 0 && Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mouseScreenPosition = Input.mousePosition;
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            x_position = Convert.ToInt32(mouseWorldPosition.x);
            y_position = Convert.ToInt32(mouseWorldPosition.y);

            Placer.x = x_position;
            Placer.y = y_position;

            if(Tiles[x_position, y_position] == 0 && ((0 <= x_position && x_position <= 20) && (0 <= y_position && y_position <= 20)))
            {
                if (Desert_Selected == true)
                {
                    GameObject newObject = Instantiate(Desert_tile, Placer, Quaternion.identity);
                    remaining_tiles--;
                    Desert_Selected = false;
                    Tiles[x_position, y_position] = 1;
                    Debug.Log(x_position + " " + y_position);
                }
                else if (Grass_Selected == true)
                {
                    GameObject newObject = Instantiate(Grass_tile, Placer, Quaternion.identity);
                    remaining_tiles--;
                    Grass_Selected = false;
                    Tiles[x_position, y_position] = 2;
                    Debug.Log(x_position + " " + y_position);
                }
                else if (Water_Selected == true)
                {
                    GameObject newObject = Instantiate(Water_tile, Placer, Quaternion.identity);
                    remaining_tiles--;
                    Water_Selected = false;
                    Tiles[x_position, y_position] = 3;
                    Debug.Log(x_position + " " + y_position);
                }
            }
        }
    }

    public void SelectDesert()
    {
        SelectType("Desert_Selected");
    }

    public void SelectGrass()
    {
        SelectType("Grass_Selected");
    }

    public void SelectWater()
    {
        SelectType("Water_Selected");
    }

    public void SelectType(string tileType)
    {
        switch (tileType)
        {
            case "Desert_Selected":

                if (Desert_Selected == true)
                {
                    Desert_Selected = false;
                }
                else
                {
                    Desert_Selected = true;
                    Grass_Selected = false;
                    Water_Selected = false;
                    remaining_tiles++;
                }

                break;

            case "Grass_Selected":

                if (Grass_Selected == true)
                {
                    Grass_Selected = false;
                }
                else
                {
                    Desert_Selected = false;
                    Grass_Selected = true;
                    Water_Selected = false;
                    remaining_tiles++;
                }

                break;

            case "Water_Selected":

                if (Water_Selected == true)
                {
                    Water_Selected = false;
                }
                else
                {
                    Desert_Selected = false;
                    Grass_Selected = false;
                    Water_Selected = true;
                    remaining_tiles++;
                }

                break;
        }
    }
}
