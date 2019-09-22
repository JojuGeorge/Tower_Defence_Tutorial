﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    private static BuildManager _instance;
    public static BuildManager Instance { get { return _instance; } }

    private TurretBlueprint _turretToBuild;

    [SerializeField] private GameObject _buildEffect;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money > _turretToBuild.cost; } }
    public GameObject standaredTurret, missileTurret, laserTurret;



    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }



    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }


    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        GameObject _turret = Instantiate(_turretToBuild.turret, node.GetBuildPosition, Quaternion.identity) as GameObject;
        node.turret = _turret;

        GameObject effect = Instantiate(_buildEffect, node.GetBuildPosition, Quaternion.identity) as GameObject;
        Destroy(effect, 3f);

        PlayerStats.money -= _turretToBuild.cost;

        Debug.Log("Turret purchased - money left = " + PlayerStats.money);
    }
}
