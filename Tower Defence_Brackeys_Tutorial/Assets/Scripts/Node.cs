using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _errorColor;

    [SerializeField] private Vector3 _positionOffset;       // To correctly place the tower on the node
    public Vector3 GetBuildPosition { get { return transform.position + _positionOffset; } }

    private Color _startColor;
    private Renderer _rend;
    
    [Header("Optional")]
    public GameObject turret;
    public TurretBlueprint blueprint;       // set in BuildTurretOn() in buildmanager.cs
    public bool isUpgraded;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }




    // When mouse enters this gameobject change its color
    private void OnMouseEnter()
    {
        if (!BuildManager.Instance.CanBuild) { return; }        // If no turret selected then no need to highlight
        if (EventSystem.current.IsPointerOverGameObject()) { return; }      // If we are hovering over UI

        if (turret == null && BuildManager.Instance.HasMoney)
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
        if (EventSystem.current.IsPointerOverGameObject()) { return; }   // If we are hovering over UI

        if (turret != null)                                             // If there's a turrent in this node then
        {
            BuildManager.Instance.SelectNode(this);             // For getting this node to display sell/ updgrade ui on turret
            print("cant build turret here");
            return;
        }

        if (!BuildManager.Instance.CanBuild) { return; }      // If no turrets selected do nothing

        // build a turret
        BuildManager.Instance.BuildTurretOn(this);
    }
}
