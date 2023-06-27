
using UnityEngine;

public class TileModel
{
    private bool isOffset;

    public TileModel(bool isOffset)
    {
        this.isOffset = isOffset;
    }

    public bool IsOffset
    {
        get { return isOffset; }
        set { isOffset = value; }
    }
}
