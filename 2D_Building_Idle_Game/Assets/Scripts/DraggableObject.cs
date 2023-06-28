
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DraggableObject : MonoBehaviour
{
    protected Vector3 offset;
    protected bool isDraggable = true;
    [HideInInspector] public static GameObject[] otherTargets;
    [HideInInspector] public static GameObject[] houseTargets;
    [HideInInspector] public static GameObject[] trainTargets;
    protected SpriteRenderer spriteRenderer;
    protected bool isoccupiedArea = false;
    protected int colliderCount = 0;
    protected int buildingIndex = -1;

    protected virtual void Awake()
    {
        switch (gameObject.tag)
        {
            case "Pawn":
                buildingIndex = 0;
                otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
                break;
            case "House":
                buildingIndex = 1;
                houseTargets = GameObject.FindGameObjectsWithTag("HouseTarget");
                break;
            case "Castle":
                buildingIndex = 2;
                otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
                break;
            case "Flag":
                buildingIndex = 3;
                otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
                break;
            case "Sailboat":
                buildingIndex = 4;
                otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
                break;
            case "Train":
                buildingIndex = 5;
                trainTargets = GameObject.FindGameObjectsWithTag("TrainTarget");
                break;
        }      
    }

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnMouseDown()
    {
        if (isDraggable)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    protected virtual void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + offset;

            if (AreaChecker.isInArea(transform.position.x, transform.position.y) && !isoccupiedArea)
                spriteRenderer.color = new Color(0f, 1f, 0f, .5f);
            else
                spriteRenderer.color = new Color(1f, 0f, 0f, .5f);
        }
    }

    protected virtual void OnMouseUp()
    {
        if (AreaChecker.isInArea(transform.position.x, transform.position.y) && !isoccupiedArea)
        {
            if (buildingIndex == 1)
            {
                int nearestTargetIndex = NearestTarget.FindTheNearestTarget(houseTargets, transform.position);
                GameObject nearestTarget = houseTargets[nearestTargetIndex];
                transform.position = nearestTarget.transform.position;


                spriteRenderer.color = new Color(0f, 0f, 1f, 1f);
                spriteRenderer.sortingOrder = 0;

                if (isDraggable)
                    ResourcesManager.PayForBuilding(buildingIndex);

                StartCoroutine(ResourcesManager.GenerateResources(gameObject, nearestTarget));
            }
            else if (buildingIndex == 5) 
            {
                int nearestTargetIndex = NearestTarget.FindTheNearestTarget(trainTargets, transform.position);
                GameObject nearestTarget = trainTargets[nearestTargetIndex];
                transform.position = nearestTarget.transform.position;


                spriteRenderer.color = new Color(0f, 0f, 1f, 1f);
                spriteRenderer.sortingOrder = 0;

                if (isDraggable)
                    ResourcesManager.PayForBuilding(buildingIndex);

                StartCoroutine(ResourcesManager.GenerateResources(gameObject, nearestTarget));
            }
            else
            {
                int nearestTargetIndex = NearestTarget.FindTheNearestTarget(otherTargets, transform.position);
                GameObject nearestTarget = otherTargets[nearestTargetIndex];
                transform.position = nearestTarget.transform.position;


                spriteRenderer.color = new Color(0f, 0f, 1f, 1f);
                spriteRenderer.sortingOrder = 0;

                if (isDraggable)
                    ResourcesManager.PayForBuilding(buildingIndex);

                StartCoroutine(ResourcesManager.GenerateResources(gameObject, nearestTarget));
            }
        }
        else
        {
            Destroy(gameObject);
        }

        isDraggable = false;

        ResourcesManager.numOfProducedPrefabs[buildingIndex] = 0;
    }

    protected Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < ResourcesManager.tagList.Length; i++)
        {
            if (collision.gameObject.tag == ResourcesManager.tagList[i])
            {
                colliderCount++;
                isoccupiedArea = true;
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < ResourcesManager.tagList.Length; i++)
        {
            if (collision.gameObject.tag == ResourcesManager.tagList[i])
            {
                colliderCount--;

                if (colliderCount <= 0)
                    isoccupiedArea = false;
            }
        }
    }
}
