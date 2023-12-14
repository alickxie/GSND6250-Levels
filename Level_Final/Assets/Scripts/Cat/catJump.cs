using UnityEngine;
using System.Collections.Generic;

public class catJump : MonoBehaviour
{
    public List<Transform> jumpEndPoints;
    public float jumpDuration = 1.0f;
    public float jumpMaxHeight = 5.0f;
    public float checkSphereRadius = 1.0f;
    public LayerMask jumpLayerMask;

    private Vector3 jumpStartPoint;
    private int currentEndPointIndex = 0;
    private bool isJumping = false;
    private float elapsedTime = 0.0f;
    private bool canJump = false;

    public PlayerMovement playerMovement;
    public CharacterController controller;

    void Update()
    {
        // Check if the player is within the check sphere
        canJump = Physics.CheckSphere(transform.position, checkSphereRadius, jumpLayerMask);

        if (canJump && Input.GetKeyDown(KeyCode.Space) && !isJumping && jumpEndPoints.Count > 0)
        {
            playerMovement.enabled = false;
            controller.enabled = false;
            StartJump();
        }

        if (isJumping)
        {
            PerformJump();
        }
        else
        {
            playerMovement.enabled = true;
            controller.enabled = true;
        }
    }

    private void StartJump()
    {
        isJumping = true;
        elapsedTime = 0.0f;
        jumpStartPoint = transform.position; // Set the current position as the start point
    }

    private void PerformJump()
    {
        if (elapsedTime < jumpDuration)
        {
            float ratio = elapsedTime / jumpDuration;
            Transform currentEndPoint = jumpEndPoints[currentEndPointIndex];
            Vector3 position = Vector3.Lerp(jumpStartPoint, currentEndPoint.position, ratio);
            float parabolicHeight = 4 * jumpMaxHeight * ratio * (1 - ratio);
            position.y += parabolicHeight;

            transform.position = position;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            isJumping = false;
            AdvanceToNextEndPoint();
        }
    }

    private void AdvanceToNextEndPoint()
    {
        currentEndPointIndex++;
        if (currentEndPointIndex >= jumpEndPoints.Count)
        {
            currentEndPointIndex = 0; // Reset to first point or alternatively stop jumping
        }
    }

    // Gizmos to draw the check sphere and parabola in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkSphereRadius);

        if (jumpEndPoints == null || jumpEndPoints.Count == 0) return;

        foreach (var endPoint in jumpEndPoints)
        {
            int segments = 20;
            Vector3 previousPoint = transform.position;

            for (int i = 1; i <= segments; i++)
            {
                float ratio = (float)i / segments;
                Vector3 lineStart = Vector3.Lerp(transform.position, endPoint.position, ratio);
                float parabolicHeight = 4 * jumpMaxHeight * ratio * (1 - ratio);
                lineStart.y += parabolicHeight;

                Gizmos.DrawLine(previousPoint, lineStart);
                previousPoint = lineStart;
            }
        }
    }
}
