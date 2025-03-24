using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public enum TileType
{
    None = 0,
    Desert = 1,
    Grass = 2,
    Water = 3,
    WheatField = 11,  // Ellenõrizd, hogy a WheatField értéke valóban 11
    Windmill = 12,
    Barn = 13,
    Fish = 14,
    Houses = 15
}


public class Tiles_Builder : MonoBehaviour
{
    public static event Action<int, int, int> OnTilePlaced;

    public Camera mainCamera;
    public int[,] Tiles = new int[21, 21];

    public TMPro.TMP_Text Tiles_Left;

    public GameObject Desert_tile, Grass_tile, Water_tile;
    public GameObject WheatField_building, Windmill_building, Barn_building, Fish_building, Houses_building;
    public GameObject Tiles_UI, Buildings_UI, Tiles_Left_UI;

    private int x_position, y_position;
    private int remaining_tiles = 3;
    private Vector2 Placer;

    private TileType selectedTile = TileType.None;

    private Dictionary<TileType, GameObject> tilePrefabs;

    private void Start()
    {
        tilePrefabs = new Dictionary<TileType, GameObject>()
        {
            { TileType.Desert, Desert_tile },
            { TileType.Grass, Grass_tile },
            { TileType.Water, Water_tile },
            { TileType.WheatField, WheatField_building },
            { TileType.Windmill, Windmill_building },
            { TileType.Barn, Barn_building },
            { TileType.Fish, Fish_building },
            { TileType.Houses, Houses_building }
        };

        for (int i = 9; i < 12; i++)
        {
            for (int j = 9; j < 12; j++)
            {
                Tiles[i, j] = (int)TileType.Grass;
            }
        }
        Tiles[10, 10] = 100; // City center
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mouseScreenPosition = Input.mousePosition;
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            x_position = Mathf.RoundToInt(mouseWorldPosition.x);
            y_position = Mathf.RoundToInt(mouseWorldPosition.y);
            Placer = new Vector2(x_position, y_position);

            TryPlaceTile();
        }
    }

    private void TryPlaceTile()
    {
        if (x_position < 0 || x_position > 20 || y_position < 0 || y_position > 20) return;

        if (selectedTile == TileType.None) return;

        if (remaining_tiles > 0 && Tiles[x_position, y_position] == (int)TileType.None)
        {
            PlaceTile(tilePrefabs[selectedTile], (int)selectedTile);
            remaining_tiles--;
            Tiles_Left.text = remaining_tiles.ToString();

        }
        else if (remaining_tiles == 0)
        {
            if ((selectedTile == TileType.WheatField || selectedTile == TileType.Windmill || selectedTile == TileType.Barn || selectedTile == TileType.Houses) && Tiles[x_position, y_position] == (int)TileType.Grass)
            {
                PlaceTile(tilePrefabs[selectedTile], (int)selectedTile);
            }
            else if (selectedTile == TileType.Fish && Tiles[x_position, y_position] == (int)TileType.Water)
            {
                PlaceTile(tilePrefabs[selectedTile], (int)selectedTile);
            }
        }
    }

    private void PlaceTile(GameObject tilePrefab, int tileType)
    {
        Instantiate(tilePrefab, Placer, Quaternion.identity);
        Tiles[x_position, y_position] = tileType;
        selectedTile = TileType.None;
        Debug.Log($"Tile placed at {x_position}, {y_position} with type {tileType}");
        OnTilePlaced?.Invoke(x_position, y_position, tileType);  // Ellenõrizd, hogy itt valóban a helyes típus megy tovább.
    }




    public void SelectTile(TileType tile)
    {
        selectedTile = selectedTile == tile ? TileType.None : tile;
    }

    public void SelectDesert() => SelectTile(TileType.Desert);
    public void SelectGrass() => SelectTile(TileType.Grass);
    public void SelectWater() => SelectTile(TileType.Water);
    public void SelectWheatField() => SelectTile(TileType.WheatField);
    public void SelectWindmill() => SelectTile(TileType.Windmill);
    public void SelectBarn() => SelectTile(TileType.Barn);
    public void SelectFish() => SelectTile(TileType.Fish);
    public void SelectHouses() => SelectTile(TileType.Houses);

    public void NextButton()
    {
        if (remaining_tiles == 0)
        {
            if (Tiles_UI) Tiles_UI.SetActive(false);
            if (Buildings_UI) Buildings_UI.SetActive(true);
            if (Tiles_Left_UI) Tiles_Left_UI.SetActive(false);
            GameManager.Instance.phasecounter++;
        }
    }
}
