using UnityEngine;

public class ObjectDraggingModel : BaseInteractionModel<ObjectDragInteractionInputSystem, DraggebleObject>
{
    private DraggebleObject _draggebleObject;

    public ObjectDraggingModel(ObjectDragInteractionInputSystem inputSystem) : base(inputSystem)
    {
        InputSystem.pointerDrag += OnDrag;
        InputSystem.pointerDown += OnDown;
        InputSystem.released += OnRelease;
    }

    ~ObjectDraggingModel() 
    {
        if (InputSystem != null)
        {
            InputSystem.pointerDrag -= OnDrag;
            InputSystem.pointerDown -= OnDown;
            InputSystem.released -= OnRelease;
        }
    }

    private void OnDown(DraggebleObject obj, Vector3 draggedPosition)
    {
        _draggebleObject = obj;
    }

    private void OnRelease()
    {
        _draggebleObject = null;
    }

    private void OnDrag(DraggebleObject obj, Vector3 draggedPosition)
    {
        if (_draggebleObject == null)
        {
            _draggebleObject = obj;
        }

        if(_draggebleObject == null)
        {
            return;
        }

        _draggebleObject.Transform.position = draggedPosition;
    }
}