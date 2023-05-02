using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // Speed at which the enemy moves
    public Transform[] waypoints; // Array of waypoints for the enemy to patrol between
    public float waitTime; // Time to wait at each waypoint

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private float waitTimer; // Timer for waiting at each waypoint
    private bool movingToWaypoint = true; // Flag to determine if the enemy is currently moving towards a waypoint or waiting at one

    private void Start()
    {
        // Set the initial position of the enemy to the first waypoint
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update()
    {
        if (movingToWaypoint)
        {
            // Move towards the current waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                movingToWaypoint = false;
                waitTimer = waitTime;
            }
        }
        else
        {
            // Wait at the current waypoint
            waitTimer -= Time.deltaTime;

            // Check if the wait time is over
            if (waitTimer <= 0)
            {
                movingToWaypoint = true;

                // Set the next waypoint
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
        }
    }
}