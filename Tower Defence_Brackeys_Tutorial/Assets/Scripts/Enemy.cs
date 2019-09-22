﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector] public float speed;

    [SerializeField] private float _health;
    [SerializeField] private int _worth = 50;
    [SerializeField] private GameObject _deathEffect;


    private void Start()
    {
        speed = startSpeed;
    }

    private void Update()
    { 
        // Health
        if(_health <= 0)
        {
            Die();
        }
    }

    

    public void TakeDamage(float amount)
    {
        _health -= amount;
    }

    public void Slow(float slowAmount) {
        speed = startSpeed * (1f - slowAmount);     // startspeed added bcos it is not modified else the enemie speed goes on slowing 
    }



    private void Die()
    {
        PlayerStats.money += _worth;            // Add money to player when the enemy dies
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
