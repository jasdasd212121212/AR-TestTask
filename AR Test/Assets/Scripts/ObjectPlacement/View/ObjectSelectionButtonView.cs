using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ObjectPreviewView), typeof(Button))]
public class ObjectSelectionButtonView : MonoBehaviour
{
    private ObjectPreviewView _view;
    private Button _button;

    private void Awake()
    {
        _view = GetComponent<ObjectPreviewView>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _view.Model.SelectObject(_view.ObjectIndex);
    }
}