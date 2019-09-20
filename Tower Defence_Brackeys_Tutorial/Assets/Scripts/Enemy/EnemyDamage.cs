using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bulletImpactParticle;


    private void OnParticleCollision(GameObject other)
    {
        //  _bulletImpactParticle.Play();
        ParticleSystem bulletImpact = Instantiate(_bulletImpactParticle, transform.position, Quaternion.identity);
        Destroy(bulletImpact, bulletImpact.main.duration);      // Destroy this impact prticle after it plays completely

        Destroy(gameObject);
    }
}
