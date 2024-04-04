using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class HexView : MonoBehaviour
{
  //  [Inject] private HexMapManager _hexMapManager;
    [HideInInspector]
    public HexMapManager _hexMapManager;
    
    [Header("Debug")]
    [SerializeField] private HexMapManager.Directions _direction;
    [SerializeField] private float _gizmoRadius = 0.25f;
    [SerializeField] private Vector3 _gizmoOffset;

    private void OnDrawGizmosSelected()
    {
        var hex = _hexMapManager.GetHexBaseByView(this);
        HexBase nachbar = null;
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.E, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.E ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.W, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.W ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.NW, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.NW ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.NE, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.NE ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.SE, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.SE ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
        
        if (_hexMapManager.GetNeighborHexAtDirection(hex, HexMapManager.Directions.SW, out nachbar))
        {
            Gizmos.color = _direction == HexMapManager.Directions.SW ? Color.green : Color.red;
            Gizmos.DrawSphere(nachbar.WorldPosition() + _gizmoOffset, _gizmoRadius);
        }
    }
}