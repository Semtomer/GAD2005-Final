
/*
 * This interface defines the methods used to save and load game state data. 
 * The SaveGameState method is used to save the game state. 
 * The LoadGameState method is used to load the saved game state.
 */

public interface IDataManager
{
    void SaveGameState(GameState gameState);
    GameState LoadGameState();
}