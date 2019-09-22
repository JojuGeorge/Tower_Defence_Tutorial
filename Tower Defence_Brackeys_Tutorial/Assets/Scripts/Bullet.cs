using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _impactParticle;
    [SerializeField] private float _explosionRadius = 0f;

    private Transform _target = null;

    private void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        // todo : if the missile tracks a target and fires but before hitting enemy if it is destroyed by the other turret then the missile disappears

        // For heat seeking like funcitonality. locking on to a target
        Vector3 dir =_target.position - transform.position;     // Direction to move the bullet
        float distanceThisFrame = _speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)      // If we hit the target
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    // To get the currently tracking target
    public void Seek(Transform target)
    {
        _target = target;
    }

   private void HitTarget()
    {
        GameObject impactParticle = Instantiate(_impactParticle, transform.position, Quaternion.identity)as GameObject;
        Destroy(impactParticle, 5f);

        if (_explosionRadius > 0) {
            Explode();
        }
        else {
            Damage(_target);
        }
        Destroy(gameObject);
    }

    private void Explode()
    {
        // Detect all colliders within the range
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
       // Destroy(enemy.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
