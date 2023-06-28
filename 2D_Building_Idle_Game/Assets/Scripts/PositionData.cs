
// This class is used to represent the position of a building. It contains three coordinate values ​​x, y, and z.

[System.Serializable]
public class PositionData
{
    public float x;
    public float y;
    public float z;

    public PositionData(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}


