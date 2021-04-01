namespace Game
{
    using UnityEngine;

    /// <summary>
    /// Prefab containing actual level geometry of a tile, including its west and south walls/doors, if any.
    /// TilePrefabs are collected in a TileCollection.
    /// Each Square in a Map references a TilePrefab in a TileCollection.
    /// Each Cell (scene instance of Square) instantiates a TilePrefab.
    /// </summary>
    public class TilePrefab : MonoBehaviour
    {

        [SerializeField] private Wall westWall;
        [SerializeField] private Wall southWall;
        [SerializeField] private Wall westDoorWall;
        [SerializeField] private Wall southDoorWall;

        public Wall WestWall { get { return westWall; } }
        public Wall SouthWall { get { return southWall; } }
        public Wall WestDoorWall { get { return westDoorWall; } }
        public Wall SouthDoorWall { get { return southDoorWall; } }

    }
}
