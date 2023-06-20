
using UnityEngine;

public class DraggableCastle : MonoBehaviour
{
    private Vector3 offset;

    private bool isDraggable = true;

    private GameObject[] otherTargets;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
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

            if (AreaChecker.isInArea(transform.position.x, transform.position.y))
                spriteRenderer.color = new Color(0f, 1f, 0f, .5f);
            else
                spriteRenderer.color = new Color(1f, 0f, 0f, .5f);
        }
    }

    private void OnMouseUp()
    {
        if (AreaChecker.isInArea(transform.position.x, transform.position.y))
        {
            int nearestTargetIndex = NearestTarget.FindTheNearesTarget(otherTargets, transform.position);
            transform.position = otherTargets[nearestTargetIndex].transform.position;
            spriteRenderer.color = new Color(0f, 0f, 1f, 1f);

            if (isDraggable)
                ResourcesManager.PayForBuilding(2);
        }
        else
        {
            Destroy(gameObject);
        }

        isDraggable = false;

        ResourcesManager.numOfProducedPrefabs[2] = 0;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
