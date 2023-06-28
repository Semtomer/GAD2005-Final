
/*
 * This class represents the current state of the game. 
 * The ownedGold and ownedGem attributes hold the amount of gold and gems owned by the player. 
 * The constructedBuildings property stores the data of the constructed buildings as a BuildingData array.
 */

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