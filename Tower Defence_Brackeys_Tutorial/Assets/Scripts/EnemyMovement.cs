using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _waypointIndex = 0;
    private Enemy _enemy;

    private void Start()
    {
        _target = Waypoint.points[_waypointIndex];
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World);

        // If we've reached the next waypoint then
        if (Vector3.Distance(transform.position, _target.position) < 0.2f)
        {
            GetNextWaypoint();
        }

        _enemy.speed = _enemy.startSpeed;       // So that after laser hitting the enemy if enemy is out of range enemy needs to regain its normal speed
    }

    // Gets the next waypoint
    private void GetNextWaypoint()
    {
        _waypointIndex++;
        if (_waypointIndex < Waypoint.points.Length)
        {
            _target = Waypoint.points[_waypointIndex];
        }
        else
        {
            EndOfPath();
            return;                 // Destroy() might have a slight delay
        }
    }


    private void EndOfPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

}
