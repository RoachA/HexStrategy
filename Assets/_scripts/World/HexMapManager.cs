using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

//https://www.redblobgames.com/grids/hexagons/
public class HexMapManager : MonoBehaviour
{
    [SerializeField] private MapParams _mapParams;
    [SerializeField] private GameObject _hexPrefab;

    private List<GameObject> _hexObjList = new List<GameObject>();
    private Dictionary<HexBase, HexView> _hexToHexViewMap = new Dictionary<HexBase, HexView>();
    private Dictionary<Vector3, HexBase> _posVectorToHexBaseMap = new Dictionary<Vector3, HexBase>();

    private readonly Dictionary<Directions, Vector3> _directionVectors = new Dictionary<Directions, Vector3>(6)
    {
        {Directions.W, new Vector3(-1, 0, 1)},
        {Directions.E, new Vector3(1, 0, -1)},
        {Directions.SW, new Vector3(-1, 1, 0)},
        {Directions.SE, new Vector3(0, 1, -1)},
        {Directions.NW, new Vector3(0, -1, 1)},
        {Directions.NE, new Vector3(1, -1, 0)},
    };
    
    public enum Directions
    {
        W,
        E,
        SW,
        SE,
        NW,
        NE,
    }
    
    //----------------------->
    private void Start()
    {
        GenerateMap();
    }

    [Button]
    public void GenerateMap()
    {
        ResetMap();
        
        for (int column = 0; column < _mapParams.Column; column++)
        {
            for (int row = 0; row < _mapParams.Row; row++)
            {
                HexBase hex = new HexBase(column, row);
                var obj = Instantiate(_hexPrefab, hex.WorldPosition(), quaternion.identity, this.transform);
                obj.name = "Q :" + column.ToString() + " R: " + row.ToString() + " S: " + hex.S;
                _hexObjList.Add(obj);
                var view = obj.GetComponent<HexView>();
                view._hexMapManager = this;
                _hexToHexViewMap.Add(hex, view);
                _posVectorToHexBaseMap.Add(new Vector3(hex.Q, hex.R, hex.S), hex);
            }
        }
    }

    [Button]
    public void ResetMap()
    {
        if (_hexObjList == null || _hexObjList.Count == 0) return;

        foreach (var obj in _hexObjList)
        {
            DestroyImmediate(obj);
        }
        
        _hexObjList.Clear();
        _hexToHexViewMap.Clear();
        _posVectorToHexBaseMap.Clear();
    }

    #region Helpers

    /// <summary>
    /// Return vector value of a given direction, vector value is needed to work with the mapped data.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public Vector3 GetDirectionVector(Directions direction)
    {
        if (_directionVectors.TryGetValue(direction, out Vector3 directionVector))
        {
            return directionVector;
        }
        else
        {
            Debug.LogWarning("Direction " + direction + " not found in dictionary.");
            return Vector3.zero; 
        }
    }

    /// <summary>
    /// Provides the neighbor at direction if it exists.
    /// </summary>
    /// <param name="targetHex">whose neighbor</param>
    /// <param name="direction">which direction to check for neighbor</param>
    /// <param name="returnedHex">neighboring hex</param>
    /// <returns></returns>
    public bool GetNeighborHexAtDirection(HexBase targetHex, Directions direction, out HexBase returnedHex)
    {
        returnedHex = null;
        var directionVector = GetDirectionVector(direction);
        var targetHexID = new Vector3(
            targetHex.Q + directionVector.x, 
            targetHex.R + directionVector.y,
            targetHex.S + directionVector.z
            );
        
        if (_posVectorToHexBaseMap.TryGetValue(targetHexID, out var hex))
        {
            returnedHex = hex;
            return true;
        }
    
        return false;
    }
    
    public HexBase GetHexBaseByView(HexView hexView)
    {
        return _hexToHexViewMap.FirstOrDefault(pair => pair.Value == hexView).Key;
    }

    #endregion

    private void OnDrawGizmos()
    {
        foreach (var obj in _hexObjList)
        {
            Handles.Label(obj.transform.position + Vector3.left * .25f, obj.name);
        }
    }
}

[Serializable]
public struct MapParams
{
    public int Column;
    public int Row;

    public MapParams(int column, int row)
    {
        Row = row;
        Column = column;
    }
}

/*function cube_to_axial(cube):
var q = cube.q
var r = cube.r
return Hex(q, r)

function axial_to_cube(hex):
var q = hex.q
var r = hex.r
var s = -q-r
return Cube(q, r, s)*/