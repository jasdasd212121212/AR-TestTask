using UnityEngine;
using UnityEngine.UI;

public class ObjectPreviewView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public ObjectPlacementModel Model { get; private set; }
    public int ObjectIndex { get; private set; }

    public void Initialize(Sprite image, ObjectPlacementModel model, int objectcIndex)
    {
        if (image == null)
        {
            _image = GetComponent<Image>();
        }

        Model = model;

        _image.sprite = image;
        ObjectIndex = Mathf.Clamp(objectcIndex, 0, int.MaxValue);
    }
}