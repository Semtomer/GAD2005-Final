
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    public static GameObject[][] reconstructedObjects = new GameObject[6][]
    {
        new GameObject[50],
        new GameObject[50],
        new GameObject[50],
        new GameObject[50],
        new GameObject[50],
        new GameObject[50]
    };

    public static bool isNeedToRun = false;

    public static void JsonSave(int ownedGold, int ownedGem, GameObject[] draggablePrefabs)
    {
        BuildingData[] constructedBuildings = FindConstructedBuildingsData(draggablePrefabs);
        GameState gameState = new GameState(ownedGold, ownedGem, constructedBuildings);
        string jsonString = JsonUtility.ToJson(gameState);
        File.WriteAllText(Application.dataPath + "/Saves/GameState.json", jsonString);
    }

    public static void JsonLoad(GameObject[] draggablePrefabs)
    {
        string path = Application.dataPath + "/Saves/GameState.json";

        if (File.Exists(path))
        {
            string jsonReadValue = File.ReadAllText(path);
            GameState gameState = JsonUtility.FromJson<GameState>(jsonReadValue);

            ResourcesManager.ownedGold = gameState.ownedGold;
            ResourcesManager.ownedGem = gameState.ownedGem;

            RebuildOfConstructedBuildings(gameState.constructedBuildings, draggablePrefabs);
        }
        else
        {
            Debug.Log("Save file is not found in " + Application.dataPath + "/Saves/");
        }
    }

    static BuildingData[] FindConstructedBuildingsData(GameObject[] draggablePrefabs)
    {
        BuildingData[] buildingDataArray = new BuildingData[draggablePrefabs.Length];

        for (int i = 0; i < draggablePrefabs.Length; i++)
        {
            string tag = draggablePrefabs[i].tag;
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            PositionData[] positions = new PositionData[gameObjects.Length];

            int count = 0;
            for (int j = 0; j < gameObjects.Length; j++)
            {
                RectTransform rectTransform = gameObjects[j].GetComponent<RectTransform>();
                if (rectTransform.localPosition.x > 0.5f)
                {
                    positions[count] = new PositionData(rectTransform.localPosition.x,
                        rectTransform.localPosition.y,
                        rectTransform.localPosition.z);
                    count++;
                }
            }

            buildingDataArray[i] = new BuildingData(count, positions);
        }

        return buildingDataArray;
    }

    static void RebuildOfConstructedBuildings(BuildingData[] constructedBuildings, GameObject[] draggablePrefabs)
    {
        for (int i = 0; i < constructedBuildings.Length; i++)
        {
            int count = constructedBuildings[i].count;
            PositionData[] positions = constructedBuildings[i].positions;

            for (int j = 0; j < count; j++)
            {
                PositionData positionData = positions[j];
                Vector3 position = new Vector3(positionData.x, positionData.y, positionData.z);

                reconstructedObjects[i][j] = Instantiate(draggablePrefabs[i], position, Quaternion.identity);
                reconstructedObjects[i][j].GetComponent<SpriteRenderer>().enabled = true;
                reconstructedObjects[i][j].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

        isNeedToRun = true;
    }
}
