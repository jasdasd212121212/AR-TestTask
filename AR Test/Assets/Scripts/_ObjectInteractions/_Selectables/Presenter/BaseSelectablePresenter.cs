using Zenject;
using UnityEngine;

public abstract class BaseSelectablePresenter<TModel, TInputSystem, TObject, TData> : MonoBehaviour
    where TModel : BaseSelectableModel<TInputSystem, TObject, TData>
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
    where TObject : BaseInteractebleObject
{
    private TModel _model;

    protected TModel Model => _model;

    [Inject]
    private void Construct(TModel model)
    {
        _model = model;
        OnConstruct();
    }

    protected virtual void OnConstruct() { }
}