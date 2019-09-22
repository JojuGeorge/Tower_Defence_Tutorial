using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _value = 50;

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

        // Health
        if(_health <= 0)
        {
            Die();
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


    public void TakeDamage(int amount)
    {
        _health -= amount;
    }


    private void Die()
    {
        PlayerStats.money += _value;            // Add money to player when the enemy dies
        Destroy(gameObject);
    }
}
