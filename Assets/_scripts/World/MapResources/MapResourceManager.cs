using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class handles the resource distribution among tiles. also can be used to inquery the resource data of a tile.
/// also any change made to a tile is handled by this. resource-wise.
/// </summary>
public class MapResourceManager : MonoBehaviour
{
    public Dictionary<HexBase, List<IMapResource>> _hexResourcesMap = new Dictionary<HexBase, List<IMapResource>>();
    
}
