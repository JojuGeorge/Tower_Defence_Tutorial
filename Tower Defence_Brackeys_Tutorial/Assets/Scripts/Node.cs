﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _errorColor;
    [SerializeField] private GameObject _turret;
    [SerializeField] private Vector3 _positionOffset;       // To correctly place the tower on the node

    private Color _startColor;
    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }




    // When mouse enters this gameobject change its color
    private void OnMouseEnter()
    {
        if (_turret == null)
        {
            _rend.material.color = _hoverColor;
        }else
        {
            _rend.material.color = _errorColor;
        }
    }
    // When mouse exits this gameobject change its color back
    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    // When clicking the mosue button
    private void OnMouseDown()
    {
        if(_turret != null)                 // If there's a turrent in this node then
        {
            print("cant build turret here");
            return;
        }

        // build a turret
        GameObject turretToBuild = BuildManager.Instance.TurretToBuild;
        _turret = Instantiate(turretToBuild, transform.position + _positionOffset, Quaternion.identity) as GameObject;
    }
}