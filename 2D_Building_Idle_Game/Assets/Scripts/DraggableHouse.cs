
using UnityEngine;

public class DraggableHouse : MonoBehaviour
{
    private Vector3 offset;

    private bool isDraggable = true;

    public static GameObject[] houseTargets;

    private SpriteRenderer spriteRenderer;

    private bool isoccupiedArea = false;
    private int colliderCount = 0;

    private void Awake()
    {
        houseTargets = GameObject.FindGameObjectsWithTag("HouseTarget");
    }

    private void Start()
    {  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (isDraggable)
        {
            GetComponent<SpriteRenderer>().enabled = true;

            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
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

    private void OnMouseUp()
    {
        if (AreaChecker.isInArea(transform.position.x, transform.position.y) && !isoccupiedArea)
        {
            int nearestTargetIndex = NearestTarget.FindTheNearestTarget(houseTargets, transform.position);
            GameObject nearestTarget = houseTargets[nearestTargetIndex];
            transform.position = nearestTarget.transform.position;

            spriteRenderer.color = new Color(0f, 0f, 1f, 1f);
            spriteRenderer.sortingOrder = 0;

            if (isDraggable)
                ResourcesManager.PayForBuilding(1);

            StartCoroutine(ResourcesManager.GenerateResources(gameObject, nearestTarget));
        }
        else
        {
            Destroy(gameObject);
        }

        isDraggable = false;

        ResourcesManager.numOfProducedPrefabs[1] = 0;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

    private void OnTriggerExit2D(Collider2D collision)
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
