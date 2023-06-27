
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private TileView tilePrefab;
    [SerializeField] private Transform createdTiles;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileView spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, createdTiles.transform);
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x + y) % 2 == 1;
                spawnedTile.Initialize(isOffset);
            }
        }
    }
}