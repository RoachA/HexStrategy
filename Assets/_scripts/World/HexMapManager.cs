using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class HexMapManager : MonoBehaviour
{
    [SerializeField] private MapParams _mapParams;
    [SerializeField] private GameObject _hexPrefab;

    private List<GameObject> _hexObjList = new List<GameObject>();
    
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
                _hexObjList.Add(Instantiate(_hexPrefab, hex.Position(), quaternion.identity, this.transform));
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
    }
}

[Serializable]
public struct MapParams
{
    public uint Column;
    public uint Row;

    public MapParams(uint column, uint row)
    {
        Row = row;
        Column = column;
    }
}
