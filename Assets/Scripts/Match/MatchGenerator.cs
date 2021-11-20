using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGenerator : MonoBehaviour
{
    [SerializeField] MatchPoolObjects poolObjects;
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] float heightOffset;
    [SerializeField] float widthOffset;

    private void Awake()
    {
        poolObjects.GenerateObjects(height, width);
    }

    private void Start()
    {
        float heighPosition = 0;
        float widthPosition = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                while (true)
                {
                    int location = Random.Range(0, poolObjects.objects.Count);
                    if (!poolObjects.objects[location].ifActived)
                    {
                        poolObjects.objects[location].gameObject.transform.position = new Vector3(heighPosition, widthPosition);
                        poolObjects.objects[location].ifActived = true;
                        break;
                    }
                }

                widthPosition += widthOffset;
            }
            heighPosition += heightOffset;
            widthPosition = 0f;
        }
    }
}
