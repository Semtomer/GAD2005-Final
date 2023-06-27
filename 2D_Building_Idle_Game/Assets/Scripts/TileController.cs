
using UnityEngine;

public class TileController : MonoBehaviour
{
    private TileModel tileModel;
    private TileView tileView;

    public void Initialize(bool isOffset)
    {
        tileModel = new TileModel(isOffset);
        tileView = GetComponent<TileView>();

        tileView.Initialize(tileModel.IsOffset);
    }
}