using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Plecables", menuName = "Design/Placebles")]
public class PlacebleObjectsHolder : ScriptableObject
{
    [SerializeField] private PlacebelObjectNode[] _prefabs;

    public GameObject[] Prefabs => _prefabs.Select(obj => obj.Prefab).ToArray();
    public Sprite[] Icons => _prefabs.Select(obj => obj.Icon).ToArray();
}