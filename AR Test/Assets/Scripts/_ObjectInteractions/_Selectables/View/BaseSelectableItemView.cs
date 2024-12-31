using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class BaseSelectableItemView<TModel, TInputSystem, TObject, TData> : MonoBehaviour
    where TModel : BaseSelectableModel<TInputSystem, TObject, TData>
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
    where TObject : BaseInteractebleObject
{
    private Button _button;

    private bool _isInitialized;

    protected int Index { get; private set; }
    protected TData Data { get; private set; }
    protected TModel Model { get; private set; }

    public BaseSelectableItemView<TModel, TInputSystem, TObject, TData> Initialize(TData data, TModel model, int index)
    {
        if (_isInitialized)
        {
            return this;
        }

        Index = index;
        Data = data;
        Model = model;

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);

        OnInitialize();

        _isInitialized = true;

        return this;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
        OnDestroyed();
    }

    protected virtual void OnDestroyed() { }
    protected abstract void OnInitialize();
    protected abstract void OnClick();
}