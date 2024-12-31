using UnityEngine;

public class ObjectPlacementSpawnPresenter
{
    private ObjectPlacementModel _model;
    private ObjectPlacementInputSystem _inputSystem;

    public ObjectPlacementSpawnPresenter(ObjectPlacementModel model, ObjectPlacementInputSystem inputSystem)
    {
        _model = model;
        _inputSystem = inputSystem;

        _inputSystem.touchedWorld += OnSpawn;
    }

    ~ObjectPlacementSpawnPresenter()
    {
        if (_inputSystem != null)
        {
            _inputSystem.touchedWorld += OnSpawn;
        }
    }

    private void OnSpawn(Vector3 position, Vector3 normal)
    {
        _model.SpawnCurrent(position, normal);
    }
}