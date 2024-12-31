using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseSelectableTabView<TModel, TInputSystem, TObject, TData, TView> : MonoBehaviour
    where TModel : BaseSelectableModel<TInputSystem, TObject, TData>
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
    where TObject : BaseInteractebleObject
    where TView : BaseSelectableItemView<TModel, TInputSystem, TObject, TData>
{
    [SerializeField] private GameObject _viewObject;
    [SerializeField] private Transform _origin;
    [SerializeField] private TView _viewPrefab;

    [Inject] private TModel _model;

    private List<GameObject> _views = new List<GameObject>();

    protected GenericFactory<TView> ViewsFactory { get; private set; }
    protected TModel Model => _model;

    private void Awake()
    {
        ViewsFactory = new(_viewPrefab, _origin);

        _viewObject.SetActive(false);

        _model.selected += OnSelect;
        _model.deselected += OnDeselect;
    }

    private void OnDestroy()
    {
        _model.selected -= OnSelect;
        _model.deselected -= OnDeselect;
    }

    private void OnSelect()
    {
        _viewObject.SetActive(true);

        ClearList();

        Array dataArray = GetDataIterateble(_model.Data);

        for (int i = 0; i < dataArray.Length; i++)
        {
            TView view = ViewsFactory.Create().Initialize(_model.Data, Model, i) as TView;

            _views.Add(view.gameObject);
            PostprocessViewItem(view, _model.Data);
        }
    }

    private void OnDeselect()
    {
        _viewObject.SetActive(false);
    }

    private void ClearList()
    {
        foreach (GameObject currentGameObject in _views)
        {
            Destroy(currentGameObject);
        }

        _views.Clear();
    }

    protected abstract Array GetDataIterateble(TData data);
    protected virtual void PostprocessViewItem(TView view, TData data) { }
}