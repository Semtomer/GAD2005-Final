
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraggableTrain : MonoBehaviour
{
    private Vector3 offset;
    private bool isDraggable = false;

    private GameObject[] houseTargets;
    private GameObject[] trainTargets;
    private GameObject[] otherTargets;

    private List<float> Distances;

    private void Start()
    {
        houseTargets = GameObject.FindGameObjectsWithTag("HouseTarget");
        trainTargets = GameObject.FindGameObjectsWithTag("TrainTarget");
        otherTargets = GameObject.FindGameObjectsWithTag("OtherTarget");
        Distances = new List<float>();
    }

    private void OnMouseDown()
    {
        isDraggable = true;

        transform.GetChild(0).gameObject.SetActive(true);

        Vector3 oldPosition = transform.position;
        gameObject.transform.SetParent(null);
        transform.position = oldPosition;
        
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }   
    }

    private void OnMouseUp()
    {
        isDraggable = false;

        if (AreaChecker.isInArea(transform.position.x, transform.position.y))
        {
            if (gameObject.name == "House_DraggablePiece")
            {
                transform.position = houseTargets[FindTheNearestTarget(houseTargets)].transform.position;
            }
            else if (gameObject.name == "Train_DraggablePiece")
            {
                transform.position = trainTargets[FindTheNearestTarget(trainTargets)].transform.position;
            }
            else
            {
                transform.position = otherTargets[FindTheNearestTarget(otherTargets)].transform.position;
            }
        }     
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private int FindTheNearestTarget(GameObject[] targets)
    {
        Distances.Clear();

        for (int i = 0; i < targets.Length; i++) 
        {
            Distances.Add(Vector3.Distance(targets[i].transform.position, transform.position));
        }

        float minDistance = Distances.Min();
        int minIndex = Distances.IndexOf(minDistance);

        return minIndex;
    }

    private void Update()
    {
        if (gameObject.name == "Pawn_DraggablePiece")
        {
            Debug.Log("isDraggable: " + isDraggable);
        }
    }
}
