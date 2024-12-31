using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Design/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private LayerMask _objectMask;

    public LayerMask ObjectMask => _objectMask;
}