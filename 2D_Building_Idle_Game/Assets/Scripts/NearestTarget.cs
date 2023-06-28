
//This class performs the operations of DraggableObject buildings to find the closest target object and move to the target.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearestTarget
{
    private static List<float> Distances = new List<float>();

    // Finds the closest target from position among a given targets.
    // The targets array contains transforms of target objects into which DraggableObject building can be placed.
    // Returns the transform of the nearest target.
    public static int FindTheNearestTarget(GameObject[] targetList, Vector3 transformPosition)
    {
        Distances.Clear();

        for (int i = 0; i < targetList.Length; i++)
        {
            Distances.Add(Vector3.Distance(targetList[i].transform.position, transformPosition));
        }

        float minDistance = Distances.Min();
        int minIndex = Distances.IndexOf(minDistance);

        return minIndex;
    }
}
