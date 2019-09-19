using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private Transform _turretHead;
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _enemyCheckRefreshRate = .5f;
    [SerializeField] private float _turretTurnSpeed = 5f;

    private void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, _enemyCheckRefreshRate);     // No need to check a 100 times per second
    }


    private void Update()
    {
        if (_target != null)
        {
            // For looking at the target
            LookAtTarget();
        }
    }


    // For getting the closest enemy
    private void UpdateEnemy()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();       // Find all game object with EnemyMovement.cs script
        GameObject nearstEnemy = null;
        float shortestDistance = Mathf.Infinity;                // If no enemies then the shortest distance is max

        if(enemies != null)
        {
            foreach(var enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance < shortestDistance)          // If we have the smallest distance
                {
                    nearstEnemy = enemy.gameObject; 
                    shortestDistance = distance;        // New shortest distance = this
                }
            }
        }

        if(nearstEnemy != null && shortestDistance <= _range)       // If the nearest enemy is not null and is with in the range of the turret then
        {
            _target = nearstEnemy.transform;
        }
    }



    // For looking at the target
    private void LookAtTarget()
    {
        //  _turretHead.LookAt(_target);     OR
        Vector3 dir = _target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_turretHead.rotation, lookRotation, Time.deltaTime * _turretTurnSpeed).eulerAngles;
        _turretHead.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
