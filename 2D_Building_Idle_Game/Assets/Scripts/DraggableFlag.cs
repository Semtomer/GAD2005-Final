
using UnityEngine;

public class DraggableFlag : MonoBehaviour
{
    private Vector3 offset;

    private bool isDraggable = true;

    private GameObject[] otherTargets;

    private void Start()
    {
        otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
    }

    private void OnMouseDown()
    {
        if (isDraggable)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            Vector3 oldPosition = transform.position;
            gameObject.transform.SetParent(null);
            transform.position = oldPosition;

            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + offset;

            if (AreaChecker.isInArea(transform.position.x, transform.position.y))
                GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 0f, .5f);
            else
                GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, .5f);
        }
    }

    private void OnMouseUp()
    {
        isDraggable = false;

        if (AreaChecker.isInArea(transform.position.x, transform.position.y))
        {
            int nearestTargetIndex = NearestTarget.FindTheNearesTarget(otherTargets, transform.position);
            transform.position = otherTargets[nearestTargetIndex].transform.position;
            GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
