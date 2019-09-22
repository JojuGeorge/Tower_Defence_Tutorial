using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target = null;
    private Enemy _targetEnemy;

    private float _fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    [SerializeField] private Transform _turretHead;
    [SerializeField] private Transform _fireingPoint;

    [Header("General")]
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _enemyCheckRefreshRate = .5f;
    [SerializeField] private float _turretTurnSpeed = 5f;

    [Header("Use Bullets (default)")]
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Use Laser")]
    [SerializeField] private bool _useLaser;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private ParticleSystem _laserImpactParticleSystem;
    [SerializeField] private Light _laserImpactLight;
    [SerializeField] private int _damageOverTime = 30;
    [SerializeField] private float _slowAmount = .3f;




    private void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, _enemyCheckRefreshRate);     // No need to check a 100 times per second
    }


    private void Update()
    {
        if (_target == null)
        {
            if (_useLaser)
            {
                // So that when the target becomes null the line must disappear
                if (_lineRenderer.enabled)
                {
                    _lineRenderer.enabled = false;
                    _laserImpactParticleSystem.Stop();
                    _laserImpactLight.enabled = false;
                }
            }
            return;
        }

        // For looking at the target
        LookAtTarget();

        // If we are using laser for attacking
        if (_useLaser)
        {
            Laser();
        }
        else
        {
            // For firing at the enemies
            _fireCountDown -= Time.deltaTime;
            if (_fireCountDown <= 0 && _target != null)
            {
                Shoot();
                _fireCountDown = 1f / _fireRate;
            }
        }   
    }


    // For getting the closest enemy
    private void UpdateEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();       // Find all game object with Enemy.cs script
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
            _targetEnemy = nearstEnemy.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
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
    private void Shoot()
    {
        if(_bulletPrefab == null) { return; }

        GameObject bulletGO = Instantiate(_bulletPrefab, _fireingPoint.position, _fireingPoint.rotation) as GameObject;
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null) {
            bullet.Seek(_target);
        }
        
    }


    // For lasering
    private void Laser()
    {
        //  _target.GetComponent<Enemy>().TakeDamage(_damageOverTime * Time.deltaTime);
        _targetEnemy.TakeDamage(_damageOverTime * Time.deltaTime);      // Insetead of GetComponent<>() which is very taxing
        _targetEnemy.Slow(_slowAmount);        // For making enemy slow

        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
            _laserImpactParticleSystem.Play();
            _laserImpactLight.enabled = true;
        }

        Vector3 dir = _fireingPoint.position - _target.position;
        _laserImpactParticleSystem.transform.position = _target.position + dir.normalized;    // So that the particle plays outside the enemy and not inside
        _laserImpactParticleSystem.transform.rotation = Quaternion.LookRotation(dir);               // So that the laser particles seems to be hit and bounce to enemy in dir of laser

        _lineRenderer.SetPosition(0, _fireingPoint.position);
        _lineRenderer.SetPosition(1, _target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
