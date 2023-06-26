

public class GameState
{
    public int ownedGold;
    public int ownedGem;
    public int[] countOfConsturectedBuildings;
    public float[][][] positionsOfConstructedBuilding;
    
    public GameState()
    {

    }

    public GameState(int ownedGold, int ownedGem, int[] countOfConsturectedBuildings, float[][][] positionsOfConstructedBuilding) 
    {
        this.ownedGold = ownedGold;
        this.ownedGem = ownedGem;
        this.countOfConsturectedBuildings = countOfConsturectedBuildings;
        this.positionsOfConstructedBuilding = positionsOfConstructedBuilding;
    }
}
