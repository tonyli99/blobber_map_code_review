namespace Game
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Data describing the tile and map objects in a single position on a map.
    /// </summary>
    [Serializable]
    public class Square
    {

        /// <summary>
        /// Index in TileCollection list (imported from Tiled).
        /// </summary>
        [SerializeField] private int tileId;

        /// <summary>
        /// Unique IDs of map objects in this square.
        /// </summary>
        [SerializeField] private List<int> mapObjectGids = new List<int>();

        /// <summary>
        /// Corresponding heading of each map object.
        /// </summary>
        [SerializeField] private List<Heading> mapObjectHeadings = new List<Heading>();

        public int TileId { get { return tileId; } set { tileId = value; } }
        public List<int> MapObjectGids {  get { return mapObjectGids; } }
        public List<Heading> MapObjectHeadings { get { return mapObjectHeadings; } }

    }
}
