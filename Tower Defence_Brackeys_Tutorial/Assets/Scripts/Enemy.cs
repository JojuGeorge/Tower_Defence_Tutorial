﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector] public float speed;

    [SerializeField] private float _startHealth = 100f;
    private float _health;
    [SerializeField] private int _worth = 50;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private Image _healthBar;

    private bool _isDead = false;           // bcos enemy game object may take time to destroy then update() may call and we die again and get reward

    private void Start()
    {
        _health = _startHealth;
        speed = startSpeed;
    }

    private void Update()
    { 
        // Health
        if(_health <= 0 && !_isDead)
        {
            Die();
        }
        _healthBar.fillAmount = _health / _startHealth;
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
        _isDead = true;
        WaveSpawner.enemiesAlive--;
        print("enemies alive in die method = " + WaveSpawner.enemiesAlive);

        PlayerStats.money += _worth;            // Add money to player when the enemy dies
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
