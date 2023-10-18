using System.Collections.Generic;

namespace TDA.NPC
{
    [System.Serializable]
    public class WaypointActions
    {
        public WaypointType type;
        public float duration;
    }
    public enum WaypointType
    {
        Dig,
        CarrytoCart,
        Wait
    }
    [System.Serializable]
    public class WaypointList
    {
        public List<Waypoint> _waypoints;
    }
}