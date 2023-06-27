
[System.Serializable]
public class BuildingData
{
    public int count;
    public PositionData[] positions;

    public BuildingData(int count, PositionData[] positions)
    {
        this.count = count;
        this.positions = positions;
    }
}