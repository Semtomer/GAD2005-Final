
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
