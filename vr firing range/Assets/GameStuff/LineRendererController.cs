using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public Transform Muzzel;
    public LineRenderer lineRenderer;

    private void Update()
    {
        Vector3 startPoint = Muzzel.position;
        Vector3 direction = transform.forward;
        float distance = 100f;

        RaycastHit hit;
        if (Physics.Raycast(startPoint, direction, out hit, distance))
        {
            // Hit something
            Vector3 hitPosition = hit.point;
            // Set the positions of the LineRenderer
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, hitPosition);
        }
        else
        {
            // No hit, set a default end position
            Vector3 endPosition = startPoint + (direction * distance);
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
