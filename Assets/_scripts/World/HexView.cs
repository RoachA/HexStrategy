using UnityEngine;
using Zenject;

public class HexView : MonoBehaviour, IInteractable
{
     [Inject] private HexMapManager _hexMapManager;

     [SerializeField] private MeshRenderer _renderer;
     [SerializeField] private MeshFilter _meshFilter;
     
    // private HexData _hexBaseData;
         
    [Header("Debug")]
    [SerializeField] private HexMapManager.Directions _direction;
    [SerializeField] private float _gizmoRadius = 0.25f;
    [SerializeField] private Vector3 _gizmoOffset;

    private Vector3 _initScale;

    public void InitHexView(HexDefinitionData data)
    {
        _renderer.sharedMaterial = data.ViewParams.HexBaseMaterial;
        _initScale = transform.localScale;
    }
    
    public void OnSelected() //this will not carry hexData, this will reach hexmanager, get hex data and then will let the requesting element know.
    {
    }

    public void OnInFocus()
    {
        transform.localScale = Vector3.zero;
    }

    public void OnOutFocus()
    {
        transform.localScale = _initScale;
    }

#region Gizmos
    
    private void OnDrawGizmosSelected()
    {
        var hex = _hexMapManager.GetHexBaseByView(this);
        HexData nachbar = null;
        
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
    
#endregion
}
