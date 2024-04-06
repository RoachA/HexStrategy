using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HexType", menuName = "LocalData/HexTypeObject", order = 0)]
public class HexTypeData : ScriptableObject
{
    [SerializeField] public HexSurfaceType HexType;
    [SerializeField] public string HexName;
    [SerializeField] public HexTypeViewParams ViewParams;

}

[Serializable]
public struct HexTypeViewParams
{
    public Mesh HexBaseMesh;
    public Material HexBaseMaterial;
    public Color HexBaseColor;
    public bool IsPassable;
    public Sprite HexSprite;
}

[Serializable]
public enum HexSurfaceType
{
    Ocean,
    Plains,
    Mountain,
}
