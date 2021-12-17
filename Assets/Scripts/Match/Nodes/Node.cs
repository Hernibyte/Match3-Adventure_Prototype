using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] LayerMask mouseLayer;
    [SerializeField] float collisionRadius;
    [HideInInspector] public MatchPoolObjects poolObjects;
    [HideInInspector] public bool imSelected;
    [HideInInspector] public MatchPart part;

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, collisionRadius, mouseLayer);
        if (collider != null)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                if (!imSelected)
                    poolObjects.poolSelectedParts.SelectPart(this);
                else
                    poolObjects.poolSelectedParts.RollBackSelection(this);
            }
        }
    }

    public void AskForPart()
    {
        while (true)
        {
            int location = Random.Range(0, poolObjects.objects.Count);
            if (!poolObjects.objects[location].imActived)
            {
                part = poolObjects.objects[location];
                poolObjects.objects[location].imActived = true;
                break;
            }
        }
        part.transform.position = transform.position;
    }

    public void ReturnPart()
    {
        part.imActived = false;
        part.transform.localPosition = Vector3.zero;
        part = null;
    }
}
