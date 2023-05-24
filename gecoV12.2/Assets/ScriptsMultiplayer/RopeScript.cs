using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RopeScript : MonoBehaviour
{
    public Rigidbody2D player1Rigidbody;
    public Rigidbody2D player2Rigidbody;
    public float ropeLength = 2f;
    public float maxRopeLength = 4f;
    private float currentRopeLength; // Current rope length (to be synchronized)

    public DistanceJoint2D distanceJoint1;
    public DistanceJoint2D distanceJoint2;

    private LineRenderer lineRenderer;
    public Color lineColor = Color.white; // Define the desired line color


    public void ConnectPlayers(GameObject player1, GameObject player2)
    {
        player1Rigidbody = player1.GetComponent<Rigidbody2D>();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();

        // Create the distance joints between the players and the rope
        distanceJoint1 = player1.AddComponent<DistanceJoint2D>();
        distanceJoint1.connectedBody = player2Rigidbody;
        distanceJoint1.distance = ropeLength;

        distanceJoint2 = player2.AddComponent<DistanceJoint2D>();
        distanceJoint2.connectedBody = player1Rigidbody;
        distanceJoint2.distance = ropeLength;

        // Create the Line Renderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Set the line color
        lineRenderer.material.color = lineColor;
    }

    private void Update()
    {
        // Update the rope position to be in the middle of the players
        if (player1Rigidbody != null && player2Rigidbody != null)
        {
            Vector2 middlePoint = (player1Rigidbody.position + player2Rigidbody.position) / 2f;
            transform.position = middlePoint;
        }

        // Update the line renderer positions
        lineRenderer.SetPosition(0, player1Rigidbody.position);
        lineRenderer.SetPosition(1, player2Rigidbody.position);
    }

    public void DestroyRope()
    {
        // Destroy the distance joints
        if (distanceJoint1 != null)
        {
            Destroy(distanceJoint1);
        }

        if (distanceJoint2 != null)
        {
            Destroy(distanceJoint2);
        }

        // Destroy the Line Renderer
        if (lineRenderer != null)
        {
            Destroy(lineRenderer);
        }

        // Destroy this game object
        PhotonNetwork.Destroy(gameObject);
    }
    
    private void FixedUpdate()
    {
        if (player1Rigidbody != null && player2Rigidbody != null)
        {
            // Calculate the current distance between the players
            float currentDistance = Vector2.Distance(player1Rigidbody.position, player2Rigidbody.position);

            // If the current distance exceeds the maximum rope length, adjust the distance joint distances
            if (currentDistance > currentRopeLength)
            {
                // Calculate the normalized direction between the players
                Vector2 direction = (player2Rigidbody.position - player1Rigidbody.position).normalized;

                // Calculate the target position for player 1 based on the current rope length
                Vector2 targetPosition1 = player2Rigidbody.position - direction * currentRopeLength;
                distanceJoint1.connectedAnchor = targetPosition1;

                // Calculate the target position for player 2 based on the current rope length
                Vector2 targetPosition2 = player1Rigidbody.position + direction * currentRopeLength;
                distanceJoint2.connectedAnchor = targetPosition2;

                // Calculate the force to pull the players towards each other
                float pullForce = 10f;
                Vector2 force = direction * pullForce;

                // Apply the force to player 1
                player1Rigidbody.AddForce(force);

                // Apply the force to player 2
                player2Rigidbody.AddForce(-force);
            }
        }
    }
}
