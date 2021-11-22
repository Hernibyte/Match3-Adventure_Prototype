using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPoolObjects : MonoBehaviour
{
    [SerializeField] List<MatchPart> objectsPrefabs;
    public PoolSelectedParts poolSelectedParts;

    [HideInInspector] public List<MatchPart> objects;

    public void GenerateObjects(int height, int width)
    {
        int result = (int)(height * width);
        for (int i = 0; i < objectsPrefabs.Count; i++)
        {
            for (int j = 0; j < result; j++)
            {
                objects.Add(Instantiate(objectsPrefabs[i], transform.position, Quaternion.identity, transform));
            }
        }
    }
}
