using System;
using UnityEngine;

public interface IReadOnlyPlacementModel
{
    event Action<int, Vector3, Vector3> objectSpawned;
}