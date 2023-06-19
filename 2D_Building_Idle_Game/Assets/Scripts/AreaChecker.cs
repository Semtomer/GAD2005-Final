
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    public static bool isInArea(float positionX, float positionY)
    {
        Vector3 topBorder = GameObject.FindWithTag("TopBorder").transform.position;
        Vector3 downBorder = GameObject.FindWithTag("DownBorder").transform.position;
        Vector3 rightBorder = GameObject.FindWithTag("RightBorder").transform.position;
        Vector3 leftBorder = GameObject.FindWithTag("LeftBorder").transform.position;

        if (positionX > leftBorder.x &&
            positionX < rightBorder.x &&
            positionY > downBorder.y &&
            positionY < topBorder.y)
        {
            return true;
        }

        return false;
    }
}
