
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [HideInInspector] public static int ownedGold = 10;
    [HideInInspector] public static int ownedGem = 10;

    [Header("Owned Resources Text")]
    [SerializeField] TMP_Text ownedGold_text;
    [SerializeField] TMP_Text ownedGem_text;

    //Building Costs Variables
    #region
    [Header("Building Costs")]
    [SerializeField] private int pawnGoldCost;
    [SerializeField] private int pawnGemCost;
    [SerializeField] private int houseGoldCost;
    [SerializeField] private int houseGemCost;
    [SerializeField] private int castleGoldCost;
    [SerializeField] private int castleGemCost;
    [SerializeField] private int flagGoldCost;
    [SerializeField] private int flagGemCost;
    [SerializeField] private int sailboatGoldCost;
    [SerializeField] private int sailboatGemCost;
    [SerializeField] private int trainGoldCost;
    [SerializeField] private int trainGemCost;
    #endregion

    //Building Gold Cost Texts Variables
    #region
    [Header("Building Gold Costs Text")]
    [SerializeField] private TMP_Text pawnGoldCost_text;
    [SerializeField] private TMP_Text houseGoldCost_text;
    [SerializeField] private TMP_Text castleGoldCost_text;
    [SerializeField] private TMP_Text flagGoldCost_text;
    [SerializeField] private TMP_Text sailboatGoldCost_text;
    [SerializeField] private TMP_Text trainGoldCost_text;

    #endregion

    //Building Gem Cost Texts Variables
    #region
    [Header("Building Gem Costs Text")]
    [SerializeField] private TMP_Text pawnGemCost_text;
    [SerializeField] private TMP_Text houseGemCost_text;
    [SerializeField] private TMP_Text castleGemCost_text;
    [SerializeField] private TMP_Text flagGemCost_text;
    [SerializeField] private TMP_Text sailboatGemCost_text;
    [SerializeField] private TMP_Text trainGemCost_text;
    #endregion

    //Production Times of Buildings --> Normal version
    #region
    [Header("Production Times of Buildings")]
    [SerializeField] private int pawnProductionTime;
    [SerializeField] private int houseProductionTime;
    [SerializeField] private int castleProductionTime;
    [SerializeField] private int flagProductionTime;
    [SerializeField] private int sailboatProductionTime;
    [SerializeField] private int trainProductionTime;
    #endregion

    //Production Times of Buildings --> Static version
    #region
    [Header("Production Times of Buildings")]
    [SerializeField] private static int pawnProductionTimeStatic;
    [SerializeField] private static int houseProductionTimeStatic;
    [SerializeField] private static int castleProductionTimeStatic;
    [SerializeField] private static int flagProductionTimeStatic;
    [SerializeField] private static int sailboatProductionTimeStatic;
    [SerializeField] private static int trainProductionTimeStatic;
    #endregion

    //Gold Production Amounts of Buildings every Second --> Normal version
    #region
    [Header("Gold Production Amounts of Buildings every second")]
    [SerializeField] private int pawnGoldProductionAmount;
    [SerializeField] private int houseGoldProductionAmount;
    [SerializeField] private int castleGoldProductionAmount;
    [SerializeField] private int flagGoldProductionAmount;
    [SerializeField] private int sailboatGoldProductionAmount;
    [SerializeField] private int trainGoldProductionAmount;
    #endregion

    //Gold Production Amounts of Buildings every Second --> Static version
    #region
    [Header("Gold Production Amounts of Buildings every second")]
    [SerializeField] private static int pawnGoldProductionAmountStatic;
    [SerializeField] private static int houseGoldProductionAmountStatic;
    [SerializeField] private static int castleGoldProductionAmountStatic;
    [SerializeField] private static int flagGoldProductionAmountStatic;
    [SerializeField] private static int sailboatGoldProductionAmountStatic;
    [SerializeField] private static int trainGoldProductionAmountStatic;
    #endregion

    //Gem Production Amounts of Buildings every Second --> Normal version
    #region
    [Header("Gem Production Amounts of Buildings every second")]
    [SerializeField] private int pawnGemProductionAmount;
    [SerializeField] private int houseGemProductionAmount;
    [SerializeField] private int castleGemProductionAmount;
    [SerializeField] private int flagGemProductionAmount;
    [SerializeField] private int sailboatGemProductionAmount;
    [SerializeField] private int trainGemProductionAmount;
    #endregion

    //Gem Production Amounts of Buildings every Second --> Static version
    #region
    [Header("Gem Production Amounts of Buildings every second")]
    [SerializeField] private static int pawnGemProductionAmountStatic;
    [SerializeField] private static int houseGemProductionAmountStatic;
    [SerializeField] private static int castleGemProductionAmountStatic;
    [SerializeField] private static int flagGemProductionAmountStatic;
    [SerializeField] private static int sailboatGemProductionAmountStatic;
    [SerializeField] private static int trainGemProductionAmountStatic;
    #endregion

    //Transparency Variables for Cards
    #region
    [Header("Cards")]
    [SerializeField] private GameObject pawnCard;
    [SerializeField] private GameObject houseCard;
    [SerializeField] private GameObject castleCard;
    [SerializeField] private GameObject flagCard;
    [SerializeField] private GameObject sailboatCard;
    [SerializeField] private GameObject trainCard;
    #endregion

    //Draggable Prefabs
    #region
    [Header("Prefabs")]
    [SerializeField] private GameObject pawnPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject castlePrefab;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private GameObject sailboatPrefab;
    [SerializeField] private GameObject trainPrefab;
    #endregion

    static int[] costGoldList;
    TMP_Text[] costGoldTextsList;

    static int[] costGemList;
    TMP_Text[] costGemTextsList;

    GameObject[] cardList;

    public static GameObject[] draggablePrefabs;

    public static string[] tagList;

    public static int[] numOfProducedPrefabs;

    static bool isFinished;

    void Awake()
    {
        costGoldList = new int[] { pawnGoldCost, houseGoldCost, castleGoldCost, flagGoldCost, sailboatGoldCost, trainGoldCost };
        costGoldTextsList = new TMP_Text[] { pawnGoldCost_text, houseGoldCost_text, castleGoldCost_text, flagGoldCost_text, sailboatGoldCost_text, trainGoldCost_text };

        costGemList = new int[] { pawnGemCost, houseGemCost, castleGemCost, flagGemCost, sailboatGemCost, trainGemCost };
        costGemTextsList = new TMP_Text[] { pawnGemCost_text, houseGemCost_text, castleGemCost_text, flagGemCost_text, sailboatGemCost_text, trainGemCost_text };

        pawnProductionTimeStatic = pawnProductionTime;
        pawnGoldProductionAmountStatic = pawnGoldProductionAmount;
        pawnGemProductionAmountStatic = pawnGemProductionAmount;

        houseProductionTimeStatic = houseProductionTime;
        houseGoldProductionAmountStatic = houseGoldProductionAmount;
        houseGemProductionAmountStatic = houseGemProductionAmount;

        castleProductionTimeStatic = castleProductionTime;
        castleGoldProductionAmountStatic = castleGoldProductionAmount;
        castleGemProductionAmountStatic = castleGemProductionAmount;

        flagProductionTimeStatic = flagProductionTime;
        flagGoldProductionAmountStatic = flagGoldProductionAmount;
        flagGemProductionAmountStatic = flagGemProductionAmount;

        sailboatProductionTimeStatic = sailboatProductionTime;
        sailboatGoldProductionAmountStatic = sailboatGoldProductionAmount;
        sailboatGemProductionAmountStatic = sailboatGemProductionAmount;

        trainProductionTimeStatic = trainProductionTime;
        trainGoldProductionAmountStatic = trainGoldProductionAmount;
        trainGemProductionAmountStatic = trainGemProductionAmount;

        cardList = new GameObject[] { pawnCard, houseCard, castleCard, flagCard, sailboatCard, trainCard };

        draggablePrefabs = new GameObject[] { pawnPrefab, housePrefab, castlePrefab, flagPrefab, sailboatPrefab, trainPrefab };
        numOfProducedPrefabs = new int[] {0, 0, 0, 0, 0, 0};

        tagList = new string[] { "Pawn", "House", "Castle", "Flag", "Sailboat", "Train" };
    }

    void Start()
    {
        GameManager.LoadGameState(draggablePrefabs);

        for (int i = 0; i < costGoldTextsList.Length; i++) 
        {
            costGoldTextsList[i].SetText(costGoldList[i].ToString());
        }

        for (int i = 0; i < costGemTextsList.Length; i++)
        {
            costGemTextsList[i].SetText(costGemList[i].ToString());
        }

        StartCoroutine(RunRepeatedly(0.1f));
    }

    void CheckAffordBuilding() 
    {
        ownedGold_text.SetText(ownedGold.ToString());
        ownedGem_text.SetText(ownedGem.ToString());

        for (int i = 0; i < cardList.Length; i++)
        {
            if ( ownedGold >= costGoldList[i] && ownedGem >= costGemList[i] )
            {
                cardList[i].SetActive(false);

                if (numOfProducedPrefabs[i]<1)
                {
                    Instantiate(draggablePrefabs[i]);
                    numOfProducedPrefabs[i]++;
                }             
            }
            else
            {
                cardList[i].SetActive(true);

                GameObject[] destroyableObjects = GameObject.FindGameObjectsWithTag(tagList[i]);
                List<Vector3> destroyableObjectsPositions = new List<Vector3>();

                foreach (GameObject go in destroyableObjects)
                {
                    destroyableObjectsPositions.Add(go.transform.position);
                }

                if (numOfProducedPrefabs[i] > 0)
                {
                    for (int j = 0; j < destroyableObjects.Length; j++)
                    {
                        if (!DraggableObject.isInArea(destroyableObjectsPositions[j]))
                        {
                            Destroy(destroyableObjects[j]);
                        }  
                    }

                    numOfProducedPrefabs[i]--;
                }               
            }    
        }
    }

    IEnumerator RunRepeatedly(float waitTime)
    {
        CheckAffordBuilding();
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(RunRepeatedly(0.1f));
    }

    public static void PayForBuilding(int indexOfBuilding)
    {
        ownedGold -= costGoldList[indexOfBuilding];
        ownedGem -= costGemList[indexOfBuilding];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.EditorApplication.isPlaying = false;

        //Cheat Code
        if (Input.GetKeyDown(KeyCode.P))
        {
            ownedGold += 3;
            ownedGem += 3;
        }


        if (isFinished)
        {
            GameManager.SaveGameState(ownedGold, ownedGem, draggablePrefabs);
        }

        if (GameManager.isNeedToRun)
        {
            for (int i = 0; i < GameManager.reconstructedObjects.Length; i++)
            {
                for (int j = 0; j < GameManager.reconstructedObjects[i].Length; j++)
                {
                    if (GameManager.reconstructedObjects[i] != null && GameManager.reconstructedObjects[i][j] != null)
                    {
                        if (GameManager.reconstructedObjects[i][j].tag == "House")
                        {
                            int nearestTargetIndex = NearestTarget.FindTheNearestTarget(DraggableObject.houseTargets, GameManager.reconstructedObjects[i][j].transform.position);
                            GameObject nearestTarget = DraggableObject.houseTargets[nearestTargetIndex];
                            StartCoroutine(GenerateResources(GameManager.reconstructedObjects[i][j], nearestTarget));
                        }
                        else if (GameManager.reconstructedObjects[i][j].tag == "Train")
                        {
                            int nearestTargetIndex = NearestTarget.FindTheNearestTarget(DraggableObject.trainTargets, GameManager.reconstructedObjects[i][j].transform.position);
                            GameObject nearestTarget = DraggableObject.trainTargets[nearestTargetIndex];
                            StartCoroutine(GenerateResources(GameManager.reconstructedObjects[i][j], nearestTarget));
                        }
                        else if ((GameManager.reconstructedObjects[i][j].tag == "Pawn" ||
                                 GameManager.reconstructedObjects[i][j].tag == "Castle" ||
                                 GameManager.reconstructedObjects[i][j].tag == "Flag" ||
                                 GameManager.reconstructedObjects[i][j].tag == "Sailboat"))
                        {
                            int nearestTargetIndex = NearestTarget.FindTheNearestTarget(DraggableObject.otherTargets, GameManager.reconstructedObjects[i][j].transform.position);
                            GameObject nearestTarget = DraggableObject.otherTargets[nearestTargetIndex];
                            StartCoroutine(GenerateResources(GameManager.reconstructedObjects[i][j], nearestTarget));
                        }
                    }
                }
            }

            GameManager.isNeedToRun = false;
        }
    }

    public static IEnumerator GenerateResources(GameObject building, GameObject nearestTarget)
    {
        isFinished = false;
        int productionTime = 0;
        int goldToBeProducedEverySecond = 0;
        int gemToBeProducedEverySecond = 0;

        switch (building.tag)
        {
            case "Pawn":
                productionTime = pawnProductionTimeStatic;
                goldToBeProducedEverySecond = pawnGoldProductionAmountStatic;
                gemToBeProducedEverySecond = pawnGemProductionAmountStatic;
                break;
            case "House":
                productionTime = houseProductionTimeStatic;
                goldToBeProducedEverySecond = houseGoldProductionAmountStatic;
                gemToBeProducedEverySecond = houseGemProductionAmountStatic;
                break;
            case "Castle":
                productionTime = castleProductionTimeStatic;
                goldToBeProducedEverySecond = castleGoldProductionAmountStatic;
                gemToBeProducedEverySecond = castleGemProductionAmountStatic;
                break;
            case "Flag":
                productionTime = flagProductionTimeStatic;
                goldToBeProducedEverySecond = flagGoldProductionAmountStatic;
                gemToBeProducedEverySecond = flagGemProductionAmountStatic;
                break;
            case "Sailboat":
                productionTime = sailboatProductionTimeStatic;
                goldToBeProducedEverySecond = sailboatGoldProductionAmountStatic;
                gemToBeProducedEverySecond = sailboatGemProductionAmountStatic;
                break;
            case "Train":
                productionTime = trainProductionTimeStatic;
                goldToBeProducedEverySecond = trainGoldProductionAmountStatic;
                gemToBeProducedEverySecond = trainGemProductionAmountStatic;
                break;
        }

        int decreasingTime = productionTime;

        RectTransform growingImage = nearestTarget.transform.GetChild(0).GetComponent<RectTransform>();

        float scaleFactor = 0;

        do 
        {
            yield return new WaitForSeconds(1);
            decreasingTime -= 1;

            scaleFactor += 1f / productionTime;
            growingImage.localScale = new Vector3(1, scaleFactor, 1);

            ownedGold += goldToBeProducedEverySecond;
            ownedGem += gemToBeProducedEverySecond;

            GameManager.SaveGameState(ownedGold, ownedGem, draggablePrefabs);
        } 
        while (decreasingTime != 0);

        yield return new WaitForSeconds(1);
        growingImage.localScale = new Vector3(1, 0, 1);
        Destroy(building);

        isFinished = true;
    }
}
