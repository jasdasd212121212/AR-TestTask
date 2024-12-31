using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacementInputSystem : IInputSystem
{
    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private InteractivePanel _interactivePanel;

    public event Action<Vector3, Vector3> touchedWorld;

    public ObjectPlacementInputSystem(ARRaycastManager raycastManager, InteractivePanel interactivePanel)
    {
        _raycastManager = raycastManager;
        _interactivePanel = interactivePanel;

        _interactivePanel.pointerDown += OnPointerDown;
    }

    ~ObjectPlacementInputSystem()
    {
        _interactivePanel.pointerDown -= OnPointerDown;
    }

    private void OnPointerDown(Vector2 screenPosition)
    {
        if (_raycastManager.Raycast(screenPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            touchedWorld?.Invoke(_hits[0].pose.position, (_hits[0].trackable as ARPlane).normal);
        }
    }
}