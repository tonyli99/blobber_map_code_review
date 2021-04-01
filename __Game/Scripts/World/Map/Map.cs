namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Data describing a single floor of a dungeon, consisting of a 2D array of squares.
    /// </summary>
    public class Map : ScriptableObject
    {
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private List<Square> squares = new List<Square>();

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public List<Square> Squares { get { return squares; } }

        public Square this[int x, int z]
        {
            get
            {
                var index = x + z * width;
                return (0 <= index && index < squares.Count) ? squares[index] : null;
            }
        }

        public void SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.squares = new List<Square>();
            for (int i = 0; i < (width * height); i++)
            {
                this.squares.Add(new Square());
            }
        }

    }
}
