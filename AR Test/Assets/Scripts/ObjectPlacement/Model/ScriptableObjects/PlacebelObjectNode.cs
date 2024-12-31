using System;
using UnityEngine;

[Serializable]
public class PlacebelObjectNode
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _icon;

    public GameObject Prefab => _prefab;
    public Sprite Icon => _icon;
}