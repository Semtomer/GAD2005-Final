
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraggablePawn : MonoBehaviour, Draggable
{
    private Vector3 offset;

    private bool isDraggable = true;

    private GameObject[] otherTargets;

    private List<float> Distances;

    private void Start()
    {
        otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
        Distances = new List<float>();
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
        }

        if (AreaChecker.isInArea(transform.position.x, transform.position.y))
            GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 0f, .5f);
        else
            GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, .5f);
    }

    private void OnMouseUp()
    {
        isDraggable = false;

        if (AreaChecker.isInArea(transform.position.x, transform.position.y))
        {
            transform.position = otherTargets[FindTheNearestTarget()].transform.position;
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

    private int FindTheNearestTarget()
    {
        Distances.Clear();

        for (int i = 0; i < otherTargets.Length; i++) 
        {
            Distances.Add(Vector3.Distance(otherTargets[i].transform.position, transform.position));
        }

        float minDistance = Distances.Min();
        int minIndex = Distances.IndexOf(minDistance);

        return minIndex;
    }

    private void Update()
    {
        if (gameObject.name == "Pawn_DraggablePiece")
        {
            Debug.Log("Pawn_isDraggable: " + isDraggable);
        }
    }

    
}
