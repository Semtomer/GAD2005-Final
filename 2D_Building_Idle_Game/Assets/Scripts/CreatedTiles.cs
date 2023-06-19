
using UnityEngine;

public class CreatedTiles : MonoBehaviour
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
}
