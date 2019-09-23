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


          
        

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition;
        _uI.SetActive(true);

        if (!target.isUpgraded)
        {
            _upgradeCost.text = "$" + _target.blueprint.upgradeCost.ToString();
            _upgradeButton.interactable = true;
        }
        else
        {
            _upgradeCost.text = "DONE";
            _upgradeButton.interactable = false;
        }
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
}
