
/*
 * This class provides control of the tile. The TileController class contains instances of TileModel and TileView.
 * The Initialize method is used to initialize the tile. This method creates a TileModel instance and instantiates the TileView instance.
 */

using UnityEngine;

public class TileController : MonoBehaviour
{
    private TileModel tileModel;
    private TileView tileView;

    private void Awake()
    {
        tileView = GetComponent<TileView>();
    }

    public void Initialize(bool isOffset)
    {
        tileModel = new TileModel(isOffset);
        tileView.Initialize(tileModel.IsOffset);
    }
}