
/*
 * This class represents the data of a building. The count property holds the total number of buildings. 
 * The positions property stores the positions of buildings as a PositionData array.
 */

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