
/*
 * This class is a JSON data manager class that implements the IDataManager interface. 
 * It uses the SaveGameState and LoadGameState methods to save and load the game state in JSON format.
 */

using System.IO;
using UnityEngine;

public class JsonDataManager : IDataManager
{
    private readonly string path;

    public JsonDataManager(string path)
    {
        this.path = path;
    }

    public void SaveGameState(GameState gameState)
    {
        string jsonString = JsonUtility.ToJson(gameState);
        File.WriteAllText(path, jsonString);
    }

    public GameState LoadGameState()
    {
        if (File.Exists(path))
        {
            string jsonReadValue = File.ReadAllText(path);
            GameState gameState = JsonUtility.FromJson<GameState>(jsonReadValue);
            return gameState;
        }

        return null;
    }
}