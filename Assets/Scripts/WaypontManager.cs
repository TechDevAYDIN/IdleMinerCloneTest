using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDA.NPC;
using UnityEngine;

public class WaypontManager : MonoBehaviour
{
    [SerializeField] bool isLoopable;
    [SerializeField] public List<WaypointList> waypoints;
    public List<NPCBehaviours> npcs;

    List<Task> tasks = new List<Task>();


    public async Task AssignWaypoint(NPCBehaviours npc)
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            while (true)
            {                
                int randomIndex = Random.Range(0, waypoints[i]._waypoints.Count);
                if (!waypoints[i]._waypoints[randomIndex].isOccupied)
                {
                    npc.waypoints.Add(waypoints[i]._waypoints[randomIndex]);
                    waypoints[i]._waypoints[randomIndex].isOccupied = true;
                    break;
                }
                await Task.Yield();
            }
        }
    }
    public async void MatchNpcToWaypoint()
    {
        foreach (NPCBehaviours npc in npcs)
        {            
            if (npc.currentWaypoint == null && npc.waypoints.Count == 0)
            {
                await AssignWaypoint(npc);
            }
        }        
    }
    public async void GetWaypoints(NPCBehaviours npc)
    {
        await AssignWaypoint(npc);
    }
}
