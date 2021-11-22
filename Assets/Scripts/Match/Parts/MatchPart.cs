using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    firt,
    second,
    third
}

public class MatchPart : MonoBehaviour
{
    public PartType type;
    public bool ifActived;
}
