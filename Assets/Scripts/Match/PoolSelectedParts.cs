using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSelectedParts : MonoBehaviour
{
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [HideInInspector] public List<Node> selectedNodes = new List<Node>();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CheckMatch();
            DeselectAllParts();
        }
    }

    void Select(Node node)
    {
        node.imSelected = true;
        node.part.transform.localScale = new Vector3(1.08f, 1.08f, 1f);
        selectedNodes.Add(node);
    }

    void Deselect(Node node)
    {
        node.imSelected = false;
        node.part.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void CheckMatch()
    {
        if (selectedNodes.Count >= 3)
        {
            foreach (Node node in selectedNodes)
            {
                node.ReturnPart();
                node.AskForPart();
            }
        }
    }

    public void SelectPart(Node node)
    {
        if (selectedNodes.Count == 0)
        {
            Select(node);
        }
        else
        {
            if (node.part.type == selectedNodes[selectedNodes.Count - 1].part.type)
            {
                float distance = Vector2.Distance(node.transform.position, selectedNodes[selectedNodes.Count - 1].transform.position);
                if (distance >= minDistance &&
                    distance <= maxDistance)
                {
                    Select(node);
                }
            }
        }
    }

    public void RollBackSelection(Node node)
    {
        if (selectedNodes.Count >= 2)
            if (selectedNodes[selectedNodes.Count - 2] == node)
                DeselectPart(selectedNodes[selectedNodes.Count - 1]);
    }

    public void DeselectPart(Node node)
    {
        Deselect(node);
        selectedNodes.Remove(node);
    }

    public void DeselectAllParts()
    {
        foreach (Node node in selectedNodes)
        {
            Deselect(node);
        }
        selectedNodes.Clear();
    }
}
