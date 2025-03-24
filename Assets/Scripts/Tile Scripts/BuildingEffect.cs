using UnityEngine;

public abstract class BuildingEffect : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Tiles_Builder.OnTilePlaced += CheckNewTile;
    }

    protected virtual void OnDisable()
    {
        Tiles_Builder.OnTilePlaced -= CheckNewTile;
    }

    protected abstract void CheckNewTile(int x, int y, int tileType);

    protected bool IsNeighbour(int x, int y)
    {
        int buildingX = Mathf.FloorToInt(transform.position.x);
        int buildingY = Mathf.FloorToInt(transform.position.y);

        // Ellen�rizz�k, hogy az adott koordin�t�k szomsz�dosak-e (1 poz�ci�val elt�rhetnek)
        return Mathf.Abs(buildingX - x) <= 1 && Mathf.Abs(buildingY - y) <= 1;
    }


}
