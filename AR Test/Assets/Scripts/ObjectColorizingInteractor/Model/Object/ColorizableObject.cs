using UnityEngine;

public class ColorizableObject : BaseInteractebleObject
{
    [SerializeField] private Renderer[] _renderers;

    public void SetColor(Color color)
    {
        foreach (Renderer renderer in _renderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = color;
            }
        }
    }
}