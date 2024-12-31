using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public abstract class BaseObjectInteractionInputSystem<TObject> : IInputSystem where TObject : BaseInteractebleObject
{
    private ARRaycastManager _raycastManager;
    private Transform _camera;

    private Vector3 _cachedWorldPosition;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private InteractivePanel _interactivePanel;

    private LayerMask _objectInteractionMask;

    public event Action<TObject, Vector3> pointerDown;
    public event Action<TObject, Vector3> pointerUp;
    public event Action<TObject, Vector3> pointerDrag;
    public event Action released;

    public BaseObjectInteractionInputSystem(ARRaycastManager raycastManager, InteractivePanel panel, LayerMask objectInteractionMask)
    {
        _raycastManager = raycastManager;
        _interactivePanel = panel;
        _objectInteractionMask = objectInteractionMask;

        _camera = Camera.main.transform;

        _cachedWorldPosition = Vector3.zero;

        _interactivePanel.pointerDown += OnPointerDown;
        _interactivePanel.pointerUp += OnPointerUp;
        _interactivePanel.dragged += OnPointerDrag;
    }

    ~BaseObjectInteractionInputSystem()
    {
        if (_interactivePanel != null)
        {
            _interactivePanel.pointerDown -= OnPointerDown;
            _interactivePanel.pointerUp -= OnPointerUp;
            _interactivePanel.dragged -= OnPointerDrag;
        }
    }

    private void OnPointerDown(Vector2 screenPoint) => ProcessAction(screenPoint, pointerDown);
    private void OnPointerDrag(Vector2 screenPoint) => ProcessAction(screenPoint, pointerDrag);

    private void OnPointerUp(Vector2 screenPoint)
    {
        OnRelease();

        ProcessAction(screenPoint, pointerUp);
        released?.Invoke();
    }

    private void ProcessAction(Vector2 screenPoint, Action<TObject, Vector3> callback)
    {
        TryGetObject(out TObject obj, out Vector3 worldPosition, screenPoint);

        OnInteract(obj);

        callback?.Invoke(obj, worldPosition);
    }

    private bool TryGetObject(out TObject obj, out Vector3 worldPosition, Vector2 screenPoint)
    {
        worldPosition = _cachedWorldPosition;

        if (_raycastManager.Raycast(screenPoint, _hits, TrackableType.PlaneWithinPolygon))
        {
            worldPosition = _hits[0].pose.position;
            _cachedWorldPosition = worldPosition;

            Vector3 position = _camera.position;
            Vector3 direction = worldPosition - _camera.position;
            RaycastHit hit;
            float distance = Vector3.Distance(_camera.position, worldPosition);

            if (Physics.Raycast(position, direction, out hit, distance, _objectInteractionMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out TObject hittedObject))
                {
                    obj = hittedObject;
                    return true;
                }
            }
        }

        obj = null;

        return false;
    }

    protected virtual void OnInteract(TObject obj) { }
    protected virtual void OnRelease() { }
}