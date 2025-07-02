using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaypointData", menuName = "ScriptableObjects/WaypointData", order = 1)]
public class WaypointData : ScriptableObject
{
    public List<Transform> waypoints;
}
