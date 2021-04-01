namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Tile Collection")]
    public class TileCollection : ScriptableObject
    {
        [SerializeField] private List<Tile> tiles = new List<Tile>();

        public List<Tile> Tiles { get { return tiles; } }
    }
}
