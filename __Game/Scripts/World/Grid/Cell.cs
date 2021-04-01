namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Scene instance of a single position on a grid.
    /// </summary>
    public class Cell : MonoBehaviour
    {

        /// <summary>
        /// Objects (monsters, treasure, stairs, etc.) in this cell.
        /// </summary>
        private List<MapObject> mapObjects = new List<MapObject>();

        public Wall WestWall { get; private set; }
        public Wall SouthWall { get; private set; }
        public Wall NorthWall { get; private set; }
        public Wall EastWall { get; private set; }
        public List<MapObject> MapObjects { get { return mapObjects; } }

        public void SetupWalls(Tile tile, TilePrefab tileInstance)
        {
            WestWall = SetupWall(tile.WestWallType, tileInstance.WestWall, tileInstance.WestDoorWall);
            SouthWall = SetupWall(tile.SouthWallType, tileInstance.SouthWall, tileInstance.SouthDoorWall);
            Destroy(tileInstance); // No longer need TilePrefab component on GameObject, so destroy it.
        }

        private Wall SetupWall(WallType wallType, Wall wall, Wall doorWall)
        {
            // Tiles are instantiated with all of its walls. Remove walls not needed for this cell.
            switch (wallType)
            {
                default:
                case WallType.None:
                    if (wall != null) Destroy(wall.gameObject);
                    if (doorWall != null) Destroy(doorWall.gameObject);
                    return null;
                case WallType.Wall:
                    if (doorWall != null) Destroy(doorWall.gameObject);
                    return wall;
                case WallType.Door:
                case WallType.SecretDoor:
                    if (wall != null) Destroy(wall.gameObject);
                    return doorWall;
            }
        }

        public void SetNorthAndEastWalls(Wall northWall, Wall eastWall)
        {
            NorthWall = northWall;
            EastWall = eastWall;
        }

        public Wall GetWall(Heading heading)
        {
            switch (heading)
            {
                case Heading.North:
                    return NorthWall;
                case Heading.West:
                    return WestWall;
                case Heading.South:
                    return SouthWall;
                case Heading.East:
                    return EastWall;
                default:
                    return null;
            }
        }

    }
}
