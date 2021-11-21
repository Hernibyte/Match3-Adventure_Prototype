using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    MatchPart part;

    public void AskForPart(MatchPoolObjects poolObjects)
    {
        while (true)
        {
            int location = Random.Range(0, poolObjects.objects.Count);
            if (!poolObjects.objects[location].ifActived)
            {
                part = poolObjects.objects[location];
                poolObjects.objects[location].ifActived = true;
                break;
            }
        }
        part.transform.position = transform.position;
    }
}
