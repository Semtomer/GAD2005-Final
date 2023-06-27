
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