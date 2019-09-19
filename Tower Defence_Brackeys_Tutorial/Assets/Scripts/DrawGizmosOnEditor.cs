using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawGizmosOnEditor : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        if (_points != null && _points.Length >= 1)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                Gizmos.DrawLine(_points[i].transform.position,
                                _points[i + 1 > _points.Length - 1 ? i : i + 1].transform.position);
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(_points[i].transform.position, .5f);

            }
        }
    }
}
