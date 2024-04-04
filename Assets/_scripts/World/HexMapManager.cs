using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HexMapManager : MonoBehaviour
{
    [SerializeField] private MapParams _mapParams;
    [SerializeField] private GameObject _hexPrefab;
    
    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int column = 0; column < _mapParams.Column; column++)
        {
            for (int row = 0; row < _mapParams.Row; row++)
            {
                Instantiate(_hexPrefab, new Vector3(column, 0, row), quaternion.identity, this.transform);
            }
        }
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
