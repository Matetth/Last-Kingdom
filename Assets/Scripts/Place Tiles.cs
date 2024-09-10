using System;
using UnityEngine;

public class PlaceTiles : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Desert_tile;
    public GameObject Grass_tile;
    public GameObject Water_tile;
    private int x_position;
    private int y_position;
    private Vector3 Placer;
    private int remaining_tiles = 1;
    public GameObject[,] Tiles;

    public void PlaceTile()
    {
        while (remaining_tiles > 0)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            x_position = Convert.ToInt32(mouseWorldPosition.x);
            y_position = Convert.ToInt32(mouseWorldPosition.y);
            mouseWorldPosition.z = 0;

            Placer.x = x_position;
            Placer.y = y_position;
            Placer.z = 0;

            if (Input.GetMouseButton(0))
            {
                GameObject newObject = Instantiate(Desert_tile, Placer, Quaternion.identity);
                remaining_tiles--;
            }
        }
    }
}
