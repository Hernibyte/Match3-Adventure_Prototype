using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGenerator : MonoBehaviour
{
    [SerializeField] Node nodePrefab;
    [SerializeField] MatchPoolObjects poolObjects;
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] float heightOffset;
    [SerializeField] float widthOffset;
    List<Node> nodeList = new List<Node>();

    private void Awake()
    {
        poolObjects.GenerateObjects(height, width);
    }

    private void Start()
    {
        float heighPosition = transform.position.x;
        float widthPosition = transform.position.y;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                nodeList.Add(Instantiate(nodePrefab, new Vector3(heighPosition, widthPosition), Quaternion.identity, transform));
                nodeList[nodeList.Count - 1].AskForPart(poolObjects);
                widthPosition -= widthOffset;
            }
            heighPosition += heightOffset;
            widthPosition = transform.position.y;
        }
    }
}
