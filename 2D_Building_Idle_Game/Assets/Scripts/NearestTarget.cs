
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearestTarget
{
    private static List<float> Distances = new List<float>();

    public static int FindTheNearesTarget(GameObject[] targetList, Vector3 transformPosition)
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
