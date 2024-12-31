using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class ObjectPlacementPresenter
{
    private PlacebleObjectsHolder _objectsHolder;
    private IReadOnlyPlacementModel _model;

    private GenericFactory<GameObject> _factory;

    private LayerMask _objectMask;
    private Transform _camera;

    public ObjectPlacementPresenter(PlacebleObjectsHolder objectsHolder, IReadOnlyPlacementModel model, LayerMask objectMask)
    {
        _objectsHolder = objectsHolder;
        _model = model;
        _objectMask = objectMask;

        _camera = Camera.main.transform;

        _factory = new();

        _model.objectSpawned += OnSpawn;
    }

    ~ObjectPlacementPresenter()
    {
        if (_model != null)
        {
            _model.objectSpawned -= OnSpawn;
        }
    }

    private void OnSpawn(int index, Vector3 position, Vector3 normal)
    {
        Vector3 cameraPosition = _camera.transform.position;
        Vector3 forwardDirection = cameraPosition - position;
        BurstMathUtility.ProjectOnPlane(forwardDirection, normal, out var projectedForward);
        Quaternion rotation = Quaternion.LookRotation(projectedForward, normal);

        if (Physics.Raycast(_camera.position, position - _camera.position, Vector3.Distance(_camera.position, position), _objectMask) == false)
        {
            _factory.Create(_objectsHolder.Prefabs[index], position).transform.rotation = rotation;
        }
    }
}