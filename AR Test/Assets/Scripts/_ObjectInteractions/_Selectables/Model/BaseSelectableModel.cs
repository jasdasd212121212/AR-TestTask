using System;
using UnityEngine;

public abstract class BaseSelectableModel<TInputSystem, TObject, TData> : BaseInteractionModel<TInputSystem, TObject>
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
    where TObject : BaseInteractebleObject
{
    private TObject _cachedPreviousGameObject;
    private EventBus _eventBus;

    private bool _deselectedFromBus;

    public TData Data { get; protected set; }
    protected TObject CurrentObject { get; private set; }

    public event Action selected;
    public event Action deselected;

    public BaseSelectableModel(TInputSystem inputSystem, TData data, EventBus eventBus) : base(inputSystem)
    {
        InputSystem.pointerDown += OnPointerDown;
        _eventBus = eventBus;

        _eventBus.Subscribe<DeslectEventMark>(OnReceiveDeselectEvent);

        Data = data;
    }

    ~BaseSelectableModel()
    {
        if (InputSystem != null)
        {
            InputSystem.pointerDown -= OnPointerDown;
        }

        _eventBus.Unsubscribe<DeslectEventMark>(OnReceiveDeselectEvent);
    }

    private void OnPointerDown(TObject obj, Vector3 worldPosition)
    {
        CurrentObject = obj;

        if (obj != null)
        {
            if (_cachedPreviousGameObject == CurrentObject)
            {
                _cachedPreviousGameObject = null;
                _eventBus.Invoke(new DeslectEventMark());
                _deselectedFromBus = false;
            }
            else
            {
                if (!_deselectedFromBus)
                {
                    _cachedPreviousGameObject = obj;
                    selected?.Invoke();
                }
            }
        }
        else
        {
            deselected?.Invoke();
            _cachedPreviousGameObject = null;
        }

        _deselectedFromBus = false;
    }

    private void OnReceiveDeselectEvent(DeslectEventMark mark)
    {
        _cachedPreviousGameObject = null;
        deselected?.Invoke();
        _deselectedFromBus = true;
    }

    protected virtual void OnSelect() { }
    protected virtual void OnDeselect() { }
}