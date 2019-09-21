using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBlueprint standaredTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }



    public void SelectStandaredTurret()
    {
        _buildManager.SelectTurretToBuild(standaredTurret);
        Debug.Log("Standared Turret selected");
    } 

    public void SelectMissileTurret()
    {
        _buildManager.SelectTurretToBuild(missileTurret);
        Debug.Log("Missile Turret selected");
    }

    public void SelectLaserTurret()
    {
        _buildManager.SelectTurretToBuild(laserTurret);
        Debug.Log("Laser Turret selected");
    }

   
}
