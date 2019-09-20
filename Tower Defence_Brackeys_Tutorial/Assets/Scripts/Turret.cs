using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    private float _fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    [SerializeField] private Transform _turretHead;
    [SerializeField] private ParticleSystem _bulletParticle;

    [Header("Attributes")]
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _enemyCheckRefreshRate = .5f;
    [SerializeField] private float _turretTurnSpeed = 5f;
    [SerializeField] private float _fireRate = 1f;



    private void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, _enemyCheckRefreshRate);     // No need to check a 100 times per second
    }


    private void Update()
    {
        if (_target == null)
        {
            return;
            Shoot(false);
        }

        // For looking at the target
        LookAtTarget();

        // For firing at the enemies
        _fireCountDown -= Time.deltaTime;
        if(_fireCountDown <= 0)
        {
            Shoot(true);
            _fireCountDown = 1f / _fireRate;
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
        else
        {
            Shoot(false);           // So that the turret wont continue shoooting if the enemy is out of range
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


    // For shooting the player
    private void Shoot(bool isActive)
    {
        Debug.Log("Shooting");
        var emissionModule = _bulletParticle.emission;
        emissionModule.enabled = isActive;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
