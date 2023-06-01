using UnityEngine;

public class SheepController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;

    private int currentWaypointIndex;
    private int direction = 1;

    private void Start()
    {
        currentWaypointIndex = 0;
    }

    private void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned!");
            return;
        }

        // Get the current waypoint position
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        targetPosition.y = transform.position.y; // Maintain the y-axis position

        // Move towards the target position
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Rotate to face the target position
        Vector3 directionToTarget = targetPosition - transform.position;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
        }

        // Check if the current waypoint is reached
        if (transform.position == targetPosition)
        {
            // Update the current waypoint index
            currentWaypointIndex += direction;

            // Check if we reached the end of the waypoints array
            if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
            {
                // Reverse the direction to move back and forth
                direction *= -1;

                // Clamp the index within the waypoints array range
                currentWaypointIndex = Mathf.Clamp(currentWaypointIndex, 0, waypoints.Length - 1);
            }
        }
    }
}
