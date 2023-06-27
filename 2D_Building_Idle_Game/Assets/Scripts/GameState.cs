
[System.Serializable]
public class GameState
{
    public int ownedGold;
    public int ownedGem;
    public BuildingData[] constructedBuildings;

    public GameState()
    {
    }

    public GameState(int ownedGold, int ownedGem, BuildingData[] constructedBuildings)
    {
        this.ownedGold = ownedGold;
        this.ownedGem = ownedGem;
        this.constructedBuildings = constructedBuildings;
    }
}