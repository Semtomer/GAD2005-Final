
/*
 * This class functions as a grid manager.
 * The GridManager contains the width and height values ​​of the tiles, a tile instance, and the parent of the rendered tiles.
 */

using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private TileView tilePrefab;
    [SerializeField] private Transform createdTiles;

    // The start method calls the GenerateGrid method to generate the grid.
    private void Start()
    {
        GenerateGrid();
    }

    // The GenerateGrid method loops through the specified width and height values ​​and creates a tile for each cell by calling the SpawnTile method.
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

    // The SpawnTile method creates a copy of a tile using tilePrefab and places it in the specified location.
    // It then calls other helper methods to determine the tile's name and offset state.
    // Finally, it initializes the tile by calling the InitializeTile method.
    private void SpawnTile(int x, int y)
    {
        TileView spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, createdTiles.transform);
        SetTileName(spawnedTile, x, y);
        bool isOffset = IsOffsetTile(x, y);
        InitializeTile(spawnedTile, isOffset);
    }

    // The SetTileName method is used to specify the name of a tile. Creates a string containing location information and assigns it to the name of the tile.
    private void SetTileName(TileView tile, int x, int y)
    {
        tile.name = $"Tile {x} {y}";
    }

    // The IsOffsetTile method checks whether the tile at a given position is offset.
    // Returns true if the mod 2 of the sum of the x and y values ​​is equal to 1, indicating that it is offset.
    private bool IsOffsetTile(int x, int y)
    {
        return (x + y) % 2 == 1;
    }

    // The InitializeTile method enables a tile to be initialized. If there is no TileController component in the tile, it adds it.
    // It then calls the Initialize method of the TileView instance to initialize the tile's appearance.
    private void InitializeTile(TileView tile, bool isOffset)
    {
        TileController tileController = tile.GetComponent<TileController>();
        if (tileController == null)
            tileController = tile.gameObject.AddComponent<TileController>();

        tile.Initialize(isOffset);
    }
}
