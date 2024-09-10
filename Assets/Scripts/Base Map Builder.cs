using UnityEngine;

public class Base_Map_Builder : MonoBehaviour
{
    public bool Desert_Selected = false;
    public bool Grass_Selected = false;
    public bool Water_Selected = false;
    public PlaceTiles placeTiles;

    public void DesertSelect()
    {
        if (Desert_Selected == true)
        {
            Desert_Selected = false;
        }
        else
        {
            Desert_Selected = true;
            placeTiles.PlaceTile();
        }
    }

    public void GrassSelect()
    {
        if (Grass_Selected == true)
        {
            Grass_Selected = false;
        }
        else
        {
            Grass_Selected = true;
            placeTiles.PlaceTile();
        }
    }

    public void WaterSelect()
    {
        if (Water_Selected == true)
        {
            Water_Selected = false;
        }
        else
        {
            Water_Selected = true;
            placeTiles.PlaceTile();
        }
    }
}
