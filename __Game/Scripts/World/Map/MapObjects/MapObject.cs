namespace Game
{
    using UnityEngine;

    /// <summary>
    /// Monster, interactable, etc., located on a map.
    /// </summary>
    public class MapObject : MonoBehaviour
    {

        /// <summary>
        /// Unique ID for this map object, used for serialization in Maps.
        /// </summary>
        [SerializeField] private int gid;

        /// <summary>
        /// If true and player entered square by entering level, don't interact.
        /// </summary>
        [SerializeField] private bool ignoreOnLevelEntry;

        /// <summary>
        /// Player can hear this object.
        /// </summary>
        [SerializeField] private bool isAudible;

        /// <summary>
        /// Player can hear this object when this many cells away.
        /// </summary>
        [SerializeField] private int audibleDistance = 3;

        /// <summary>
        /// Show this text when player enters audible distance.
        /// </summary>
        [SerializeField] private string noiseText;

        public int Gid { get { return gid; } set { gid = value; } }
        public bool IgnoreOnLevelEntry { get { return ignoreOnLevelEntry; } }
        public bool IsAudible { get { return isAudible; } }
        public string NoiseText { get { return noiseText; } }

        public virtual void OnPlayerEnterSquare()
        {
        }

        public virtual void OnPlayerExitingSquare()
        {
        }
    }
}
