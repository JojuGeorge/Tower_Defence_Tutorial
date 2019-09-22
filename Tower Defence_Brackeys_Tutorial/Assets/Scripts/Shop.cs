using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBlueprint standaredTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    [SerializeField] private Text _standaredTurretCost;
    [SerializeField] private Text _missileTurretCost;
    [SerializeField] private Text _laserTurretCost;


    private void Start()
    {
        _buildManager = BuildManager.Instance;
        _standaredTurretCost.text = standaredTurret.cost.ToString(); 
        _missileTurretCost.text = missileTurret.cost.ToString(); ;
        _laserTurretCost.text = laserTurret.cost.ToString();
    }



    public void SelectStandaredTurret()
    {
        _buildManager.SelectTurretToBuild(standaredTurret);
    } 

    public void SelectMissileTurret()
    {
        _buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret()
    {
        _buildManager.SelectTurretToBuild(laserTurret);
    }

   
}
