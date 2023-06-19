
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    public static bool isInArea;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DraggablePiece")
        {
            isInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "DraggablePiece")
        {
            isInArea = false;
        }
    }

    private void Update()
    {
        //Debug.Log("isInArea: " + isInArea);
    }
}
