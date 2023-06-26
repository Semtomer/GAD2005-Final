
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    static GameState gameState = new GameState();
    static float[][][] positionsOfConstructedBuilding = new float[6][][] 
    { 
        new float[50][],
        new float[50][],
        new float[50][],
        new float[50][],
        new float[50][],
        new float[50][]
    };

    public static void JsonSave(int ownedGold, int ownedGem)
    {
        gameState = new GameState(ownedGold, ownedGem, FindCountOfConsturectedBuildings(), positionsOfConstructedBuilding); 
        string jsonString = JsonUtility.ToJson(gameState);
        File.WriteAllText(Application.dataPath + "/Saves/GameState.json", jsonString);
    }

    public static void JsonLoad(GameObject[] draggablePrefabs)
    {
        string path = Application.dataPath + "/Saves/GameState.json";

        if (File.Exists(path))
        {
            string jsonReadValue = File.ReadAllText(path);
            gameState = JsonUtility.FromJson<GameState>(jsonReadValue);

            ResourcesManager.ownedGold = gameState.ownedGold;
            ResourcesManager.ownedGem = gameState.ownedGem;

            RebuildOfConstructedBuildings(gameState.countOfConsturectedBuildings, draggablePrefabs);
        }
        else 
        {
            Debug.Log("Save file is not found in " + Application.dataPath + "/Saves/");
        }   
    }

    static int[] FindCountOfConsturectedBuildings()
    {
        int[] temp = new int[6];

        //int countOfPawn = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Pawn"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfPawn++;
        //}
        //temp[0] = countOfPawn;

        int countOfPawn = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Pawn").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("Pawn")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfPawn++;

                positionsOfConstructedBuilding[0][i] = new float[3];
                positionsOfConstructedBuilding[0][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[0][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[0][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[0] = countOfPawn;

        //int countOfHouse = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("House"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfHouse++;
        //}
        //temp[1] = countOfHouse;

        int countOfHouse = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("House").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("House")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfHouse++;

                positionsOfConstructedBuilding[1][i] = new float[3];
                positionsOfConstructedBuilding[1][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[1][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[1][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[1] = countOfHouse;

        //int countOfCastle = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Castle"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfCastle++;
        //}
        //temp[2] = countOfCastle;

        int countOfCastle = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Castle").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("Castle")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfCastle++;

                positionsOfConstructedBuilding[2][i] = new float[3];
                positionsOfConstructedBuilding[2][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[2][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[2][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[2] = countOfCastle;

        //int countOfFlag = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Flag"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfFlag++;
        //}
        //temp[3] = countOfFlag;

        int countOfFlag = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Flag").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("Flag")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfFlag++;

                positionsOfConstructedBuilding[3][i] = new float[3];
                positionsOfConstructedBuilding[3][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[3][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[3][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[3] = countOfFlag;

        //int countOfSailboat = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Sailboat"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfSailboat++;
        //}
        //temp[4] = countOfSailboat;

        int countOfSailboat = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Sailboat").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("Sailboat")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfSailboat++;

                positionsOfConstructedBuilding[4][i] = new float[3];
                positionsOfConstructedBuilding[4][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[4][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[4][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[4] = countOfSailboat;

        //int countOfTrain = 0;
        //foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Train"))
        //{
        //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //    if (rectTransform.localPosition.x > 0.5f)
        //        countOfTrain++;
        //}
        //temp[5] = countOfTrain;

        int countOfTrain = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Train").Length; i++)
        {
            RectTransform rectTransform = GameObject.FindGameObjectsWithTag("Train")[i].GetComponent<RectTransform>();
            if (rectTransform.localPosition.x > 0.5f)
            {
                countOfTrain++;

                positionsOfConstructedBuilding[5][i] = new float[3];
                positionsOfConstructedBuilding[5][i][0] = rectTransform.localPosition.x;
                positionsOfConstructedBuilding[5][i][1] = rectTransform.localPosition.y;
                positionsOfConstructedBuilding[5][i][2] = rectTransform.localPosition.z;
            }
        }
        temp[5] = countOfTrain;

        return temp;
    }

    static void RebuildOfConstructedBuildings(int[] countOfBuildings, GameObject[] draggablePrefabs)
    {
        
        for (int i = 0; i < countOfBuildings.Length; i++)
        {
            for (int j = 0; j < countOfBuildings[i]; j++)
            {
                Instantiate(draggablePrefabs[i]);
            }
        }
    }
}
