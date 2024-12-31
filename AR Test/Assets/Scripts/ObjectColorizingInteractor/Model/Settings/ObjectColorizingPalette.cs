using UnityEngine;

[CreateAssetMenu(fileName = "Palette", menuName = "Design/Selectables/Palette")]
public class ObjectColorizingPalette : ScriptableObject
{
    [SerializeField] private Color[] _colors;

    public Color[] Colors => _colors;
}