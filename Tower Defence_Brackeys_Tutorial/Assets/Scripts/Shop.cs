using UnityEngine;

public class Shop : MonoBehaviour
{


    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }



    public void StandardTurretPurchase()
    {
        _buildManager.SetTurretToBuild(_buildManager.standaredTurret);
        Debug.Log("Standared Turret selected");
    } 

    public void MissileTurretPurchase()
    {
        _buildManager.SetTurretToBuild(_buildManager.missileTurret);
        Debug.Log("Missile Turret selected");
    }

    public void LaserTurretPurchase()
    {
        _buildManager.SetTurretToBuild(_buildManager.laserTurret);
        Debug.Log("Laser Turret selected");
    }

   
}
