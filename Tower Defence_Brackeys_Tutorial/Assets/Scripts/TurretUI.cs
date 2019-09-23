using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    private Node _target;

    [SerializeField] private GameObject _uI;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition;
        _uI.SetActive(true);
    }

    public void Hide()
    {
        _uI.SetActive(false);
    }
}
