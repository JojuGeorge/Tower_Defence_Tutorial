using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    private static BuildManager _instance;
    public static BuildManager Instance { get { return _instance; } }

    private GameObject _turretToBuild;
    public GameObject TurretToBuild { get { return _turretToBuild; } }

    public GameObject standaredTurret, missileTurret, laserTurret;

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }



    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}
