
public interface IDataManager
{
    void SaveGameState(GameState gameState);
    GameState LoadGameState();
}