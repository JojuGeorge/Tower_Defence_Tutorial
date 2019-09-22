using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float _speed;

    private Transform _target;
    private int _waypointIndex = 0;

    private void Start()
    {
        _target = Waypoint.points[_waypointIndex];
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        // If we've reached the next waypoint then
        if (Vector3.Distance(transform.position, _target.position) < 0.2f)
        {
            GetNextWaypoint();
        }

    }

    // Gets the next waypoint
    private void GetNextWaypoint()
    {
        _waypointIndex++;
        if(_waypointIndex < Waypoint.points.Length)
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
