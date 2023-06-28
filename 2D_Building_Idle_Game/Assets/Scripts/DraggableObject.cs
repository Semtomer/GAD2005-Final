
/*
 * The DraggableObject class is the base class that defines the draggable behavior of a game object. 
 * This class contains a boolean value called isDraggable that determines whether the game object is draggable.
 */

using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    protected Vector3 offset;
    [HideInInspector] public bool isDraggable = true;
    [HideInInspector] public static GameObject[] otherTargets;
    [HideInInspector] public static GameObject[] houseTargets;
    [HideInInspector] public static GameObject[] trainTargets;
    protected SpriteRenderer spriteRenderer;
    protected bool isoccupiedArea = false;
    protected int colliderCount = 0;
    protected int buildingIndex = -1;

    // Finds related target objects based on the building's tag and assigns them to otherTargets, houseTargets or trainTargets arrays.
    // Also, assigns buildingIndex values based on the building's tag.
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

    // It is a area controller to be used in the following methods. Returns whether the building has entered the tile area.
    public static bool isInArea(Vector3 position)
    {
        Vector3 topBorder = GameObject.FindWithTag("TopBorder").transform.position;
        Vector3 downBorder = GameObject.FindWithTag("DownBorder").transform.position;
        Vector3 rightBorder = GameObject.FindWithTag("RightBorder").transform.position;
        Vector3 leftBorder = GameObject.FindWithTag("LeftBorder").transform.position;

        if (position.x > leftBorder.x &&
            position.x < rightBorder.x &&
            position.y > downBorder.y &&
            position.y < topBorder.y)
        {
            return true;
        }

        return false;
    }

    // This is the method that works when the mouse button is clicked.
    // It checks if the building is draggable and calculates the difference between the mouse position and the building's position.
    protected virtual void OnMouseDown()
    {
        if (isDraggable)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    // It is the method that works when the mouse is dragged. Checks if the building is draggable and moves the building according to the mouse position.
    // It checks if the building is in the tile area andalso checks if the building hovers over another building and then adjusts the color of its image.
    protected virtual void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + offset;

            if (isInArea(transform.position) && !isoccupiedArea)
                spriteRenderer.color = new Color(0f, 1f, 0f, .5f);
            else
                spriteRenderer.color = new Color(1f, 0f, 0f, .5f);
        }
    }

    // This is the method that works when the mouse button is released.
    // It checks if the building is in the tile area and can be dragged, and if the building is hovering over another building.
    // If it passes the checks, it places the building at the location of the nearest target object according to the buildingIndex with PlaceTheBuilding method.
    // Changes the color of the building and finally, it starts resource production with PlaceTheBuilding method. If it fails the checks, it destroys the building. 
    protected virtual void OnMouseUp()
    {
        if (isDraggable)
        {
            if (isInArea(transform.position) && !isoccupiedArea)
            {
                if (buildingIndex == 1)
                {
                    PlaceTheBuilding(houseTargets);
                }
                else if (buildingIndex == 5)
                {
                    PlaceTheBuilding(trainTargets);
                }
                else
                {
                    PlaceTheBuilding(otherTargets);
                }
            }
            else
            {
                Destroy(gameObject);
            }

            isDraggable = false;

            ResourcesManager.numOfProducedPrefabs[buildingIndex] = 0;
        } 
    }

    // The function is explained in the one above description.
    protected virtual void PlaceTheBuilding(GameObject[] targets)
    {
        int nearestTargetIndex = NearestTarget.FindTheNearestTarget(targets, transform.position);
        GameObject nearestTarget = targets[nearestTargetIndex];
        transform.position = nearestTarget.transform.position;

        spriteRenderer.color = new Color(0f, 0f, 1f, 1f);
        spriteRenderer.sortingOrder = 0;

        if (isDraggable)
            ResourcesManager.PayForBuilding(buildingIndex);

        StartCoroutine(ResourcesManager.GenerateResources(gameObject, nearestTarget));
    }

    // Converts mouse position to world coordinates.
    protected Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Trigger methods help check if several tiles are occupied by another building.
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

    // Trigger methods help check if several tiles are occupied by another building.
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
