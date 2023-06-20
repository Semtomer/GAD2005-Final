
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    static int ownedGold = 3;
    static int ownedGem = 3;

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

    GameObject[] draggablePrefabs;

    string[] tagList;

    public static int[] numOfProducedPrefabs;

    void Awake()
    {
        costGoldList = new int[] { pawnGoldCost, houseGoldCost, castleGoldCost, flagGoldCost, sailboatGoldCost, trainGoldCost };
        costGoldTextsList = new TMP_Text[] { pawnGoldCost_text, houseGoldCost_text, castleGoldCost_text, flagGoldCost_text, sailboatGoldCost_text, trainGoldCost_text };

        costGemList = new int[] { pawnGemCost, houseGemCost, castleGemCost, flagGemCost, sailboatGemCost, trainGemCost };
        costGemTextsList = new TMP_Text[] { pawnGemCost_text, houseGemCost_text, castleGemCost_text, flagGemCost_text, sailboatGemCost_text, trainGemCost_text };

        cardList = new GameObject[] { pawnCard, houseCard, castleCard, flagCard, sailboatCard, trainCard };

        draggablePrefabs = new GameObject[] { pawnPrefab, housePrefab, castlePrefab, flagPrefab, sailboatPrefab, trainPrefab };
        numOfProducedPrefabs = new int[] {0, 0, 0, 0, 0, 0};

        tagList = new string[] { "Pawn", "House", "Castle", "Flag", "Sailboat", "Train" };
    }

    void Start()
    {       
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
                        if (!AreaChecker.isInArea(destroyableObjectsPositions[j].x, destroyableObjectsPositions[j].y))
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
        StartCoroutine(RunRepeatedly(1f));
    }

    public static void PayForBuilding(int indexOfBuilding)
    {
        ownedGold -= costGoldList[indexOfBuilding];
        ownedGem -= costGemList[indexOfBuilding];
    }

    private void Update()
    {
        //Cheat Code
        if (Input.GetKeyDown(KeyCode.P))
        {
            ownedGold += 3;
            ownedGem += 3;
        }
    }
}
