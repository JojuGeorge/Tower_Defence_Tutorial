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

    // Temporary to see if its working
    [SerializeField] private GameObject _standaredTurretPrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _turretToBuild = _standaredTurretPrefab;
    }
}
