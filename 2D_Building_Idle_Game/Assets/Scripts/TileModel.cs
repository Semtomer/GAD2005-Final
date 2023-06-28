
/*
 * This class represents the data model of the tile.
 * The TileModel class stores a boolean value called isOffset.
 * The isOffset value specifies whether the tile is offset.
 */

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
