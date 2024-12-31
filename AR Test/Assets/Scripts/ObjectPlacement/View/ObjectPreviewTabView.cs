using UnityEngine;
using Zenject;

public class ObjectPreviewTabView : MonoBehaviour
{
    [SerializeField] private ObjectPreviewView _viewPrefab;
    [SerializeField] private RectTransform _parent;

    [Inject] private PlacebleObjectsHolder _objectsHolder;
    [Inject] private ObjectPlacementModel _placementModel;

    private GenericFactory<ObjectPreviewView> _viewsFactory;

    private void Awake()
    {
        _viewsFactory = new(_viewPrefab, _parent);

        Display();
    }

    private void Display()
    {
        Sprite[] sprites = _objectsHolder.Icons;

        for (int i = 0; i < sprites.Length; i++)
        {
            _viewsFactory.Create().Initialize(sprites[i], _placementModel, i);
        }
    }
}