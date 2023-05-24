using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Seed : MonoBehaviour
{
    public enum GroundTypes
    {
        Bads = 1,
        Pit = 2,
    }
    public enum Types
    {
        Potato = 1,
        Tomato = 2,
    }
    public abstract GroundTypes Type { get; protected set; }

    public Plant Plant;
}
