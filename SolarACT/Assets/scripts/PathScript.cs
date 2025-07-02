using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public WaypointData waypointData; // Reference to the ScriptableObject
    public float speed = 5f;
    public float reachThreshold = 0.1f;

    private int currentWaypointIndex = 0;

    void Start()
    {
        if (waypointData == null || waypointData.waypoints.Count == 0)
        {
            Debug.LogError("WaypointData is not set or empty!");
            return;
        }
    }

    void Update()
    {
        if (waypointData == null || waypointData.waypoints.Count == 0) return;

        Transform targetWaypoint = waypointData.waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetWaypoint.position) < reachThreshold)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypointData.waypoints.Count)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (waypointData == null || waypointData.waypoints.Count == 0) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < waypointData.waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypointData.waypoints[i].position, waypointData.waypoints[i + 1].position);
        }
        Gizmos.DrawLine(waypointData.waypoints[waypointData.waypoints.Count - 1].position, waypointData.waypoints[0].position);
    }
}
