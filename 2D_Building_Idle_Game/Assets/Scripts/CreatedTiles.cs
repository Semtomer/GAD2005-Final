
using UnityEngine;

public class CreatedTiles : MonoBehaviour
{
    public static bool isInArea = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DraggablePiece")
        {
            Debug.Log("içeride");
            isInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DraggablePiece")
        {
            Debug.Log("dýþarýda");
            isInArea = false;
        }
    }
}
