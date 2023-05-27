using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private void Update()
    {
        // Example: Update the line rendering in the Update method
        Vector3 startPoint = transform.position;
        Vector3 direction = transform.forward;
        float distance = 100f; // Example: the length of the line

        RenderLine(startPoint, direction, distance);
    }

    private void RenderLine(Vector3 startPoint, Vector3 direction, float distance)
    {
        Debug.DrawRay(startPoint, direction * distance, Color.red); // Example: render a red line
    }
}
