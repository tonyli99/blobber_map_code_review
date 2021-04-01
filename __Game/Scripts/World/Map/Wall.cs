namespace Game
{
    using UnityEngine;

    /// <summary>
    /// Defines a scene instance of a wall or door in a TilePrefab.
    /// </summary>
    public class Wall : MonoBehaviour
    {

        [SerializeField] private WallType wallType;
        [SerializeField] private Transform doorHinge;

        public WallType WallType { get { return wallType; } }
        public Transform DoorHinge { get { return doorHinge; } }

        public bool IsWall { get { return wallType == WallType.Wall; } }
        public bool IsDoor { get { return wallType == WallType.Door; } }

    }
}
