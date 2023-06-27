
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

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnTile(x, y);
            }
        }
    }

    private void SpawnTile(int x, int y)
    {
        TileView spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, createdTiles.transform);
        SetTileName(spawnedTile, x, y);
        bool isOffset = IsOffsetTile(x, y);
        InitializeTile(spawnedTile, isOffset);
    }

    private void SetTileName(TileView tile, int x, int y)
    {
        tile.name = $"Tile {x} {y}";
    }

    private bool IsOffsetTile(int x, int y)
    {
        return (x + y) % 2 == 1;
    }

    private void InitializeTile(TileView tile, bool isOffset)
    {
        TileController tileController = tile.GetComponent<TileController>();
        if (tileController == null)
            tileController = tile.gameObject.AddComponent<TileController>();

        tile.Initialize(isOffset);
    }
}
