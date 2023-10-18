using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MineSetting", menuName = "TechDevAydin/Add Mine Setting", order = 1)]
public class BaseMineSettings : ScriptableObject
{
    public int _tunnelCount = 1;
    [SerializeField]
    public List<TunnelSetting> tunnels;
}

[Serializable]
public class TunnelSetting
{
    public TunnelType tunnelType;
    public int _maxTunnelLevel = 1;
    public List<TunnelLevelSettings> levelSettings = new List<TunnelLevelSettings>();
}

[Serializable]
public class TunnelLevelSettings
{
    public int _cost = 100;
    public float _speed = 1f;
    public int _productCount = 100;
}
public enum TunnelType
{
    Coal,
    Gold,
    Diamond
}
