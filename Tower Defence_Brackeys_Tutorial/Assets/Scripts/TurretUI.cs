using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private Node _target;

    [SerializeField] private GameObject _uI;
    [SerializeField] private Text _upgradeCost;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _sellPrice;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition;
        _uI.SetActive(true);

        if (!target.isUpgraded && PlayerStats.money > _target.blueprint.upgradeCost)
        {
            _upgradeCost.text = "$" + _target.blueprint.upgradeCost.ToString();
            _upgradeButton.interactable = true;
        }
        else if (target.isUpgraded)
        {
            _upgradeCost.text = "DONE";
            _upgradeButton.interactable = false;
        }
        else if(PlayerStats.money < _target.blueprint.upgradeCost){
            _upgradeButton.interactable = false;
        }

        _sellPrice.text = _target.blueprint.SellingPrice().ToString();
    }

        public void Hide()
    {
        _uI.SetActive(false);
    }

    public void Upgrade()
    {
        BuildManager.Instance.UpgradeTurret(_target, _target.blueprint);
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        BuildManager.Instance.SellTurret(_target, _target.blueprint);
        BuildManager.Instance.DeselectNode();
    }
}
