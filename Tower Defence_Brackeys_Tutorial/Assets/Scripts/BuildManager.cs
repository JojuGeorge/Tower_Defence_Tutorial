using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    private static BuildManager _instance;
    public static BuildManager Instance { get { return _instance; } }

    private TurretBlueprint _turretToBuild;
    private Node _selectedNode;
    public TurretUI turretUI;


    [SerializeField] private GameObject _buildEffect;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money > _turretToBuild.cost; } }

    private GameObject _turret;



    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }

    public void SelectNode(Node node) {
        // for toggling the UI on and off
        if(_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _turretToBuild = null;          // since we need to get the turret on this node put null on already selected turret in this script
        turretUI.SetTarget(node);      // set node to display the ui
    }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        DeselectNode();           
    }


    public void DeselectNode()
    {
        _selectedNode = null;
        turretUI.Hide();    // when we select a turret to build hide the turret ui
        return;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

         _turret = Instantiate(_turretToBuild.turret, node.GetBuildPosition, Quaternion.identity) as GameObject;
        node.turret = _turret;
        node.blueprint = _turretToBuild;

        GameObject effect = Instantiate(_buildEffect, node.GetBuildPosition, Quaternion.identity) as GameObject;
        Destroy(effect, 3f);

        PlayerStats.money -= _turretToBuild.cost;

    }

    public void UpgradeTurret(Node node, TurretBlueprint blueprint)
    {
        _turretToBuild = blueprint;
        node.isUpgraded = true;

        if (PlayerStats.money < _turretToBuild.upgradeCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        Destroy(_selectedNode.turret);           // Destroy the previous gameobject

        GameObject _upgradedTurret = Instantiate(_turretToBuild.upgradedTurret, node.GetBuildPosition, Quaternion.identity) as GameObject;
        node.turret = _upgradedTurret;
        node.blueprint = blueprint;

        GameObject effect = Instantiate(_buildEffect, node.GetBuildPosition, Quaternion.identity) as GameObject;
        Destroy(effect, 3f);

        PlayerStats.money -= _turretToBuild.upgradeCost;
    }

    public void SellTurret(Node node, TurretBlueprint blueprint)
    {

        node.isUpgraded = false;
        PlayerStats.money += blueprint.SellingPrice();

        Destroy(_selectedNode.turret);
        blueprint = null;
    


    }
}
