namespace Game
{
    using UnityEngine;

    /// <summary>
    /// Manages the scene instance of a map, consisting of a grid of cells.
    /// Would have preferred to name this class Grid, but Unity warns if a
    /// class is named Grid even if it's in a different namespace.
    /// </summary>
    public class GridManager
    {

        private Cell[,] cells;

        public Cell this[int x, int z] { get { return cells[x, z]; } }

        public Cell this[Vector3Int position] { get { return this[position.x, position.z]; } }

        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;

        public void CreateGrid(Map map)
        {
            DestroyGrid();

            var tileCollection = Game.TileCollection;
            var mapObjectCollection = Game.MapObjectCollection;

            // Create cells from tiles:
            Width = map.Width;
            Height = map.Height;
            cells = new Cell[map.Width, map.Height];
            for (int z = 0; z < map.Height; z++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    var position = new Vector3(x, 0, z);
                    var square = map[x, z];
                    var tile = tileCollection.Tiles[square.TileId];
                    var tileInstance = GameObject.Instantiate(tile.TilePrefab, position, Quaternion.identity);
                    var cell = tileInstance.gameObject.AddComponent<Cell>();
                    cell.name = $"Cell {x},{z}";
                    cell.SetupWalls(tile, tileInstance);
                    cells[x, z] = cell;

                    // Add map objects:
                    for (int i = 0; i < square.MapObjectGids.Count; i++)
                    {
                        var mapObjectGid = square.MapObjectGids[i];
                        var heading = square.MapObjectHeadings[i];
                        var mapObjectPrefab = mapObjectCollection.GetMapObjectPrefab(mapObjectGid);
                        if (mapObjectPrefab == null)
                        {
                            Debug.Log($"[{x},{z}]: Can't find map object with gid {mapObjectGid}");
                        }
                        else
                        {
                            var mapObject = GameObject.Instantiate(mapObjectPrefab, position, Quaternion.identity);
                            mapObject.name = mapObjectPrefab.name;
                            mapObject.transform.SetParent(cell.transform);
                            cells[x, z].MapObjects.Add(mapObject);
                            switch (heading)
                            {
                                case Heading.East:
                                    mapObject.transform.Rotate(Vector3.up, 90);
                                    break;
                                case Heading.South:
                                    mapObject.transform.Rotate(Vector3.up, 180);
                                    break;
                                case Heading.West:
                                    mapObject.transform.Rotate(Vector3.up, -90);
                                    break;
                            }
                        }
                    }
                }
            }

            // Link North, East walls to neighbors' South, West walls:
            for (var z = 0; z < map.Height - 1; z++)
            {
                for (var x = 0; x < map.Width - 1; x++)
                {
                    cells[x, z].SetNorthAndEastWalls(cells[x, z + 1].SouthWall, cells[x + 1, z].WestWall);
                }
            }
        }

        public void DestroyGrid()
        {
            for (int z = 0; z < Height; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GameObject.Destroy(cells[x, z].gameObject);
                }
            }
        }

    }
}
