using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TDA.NPC;
using UnityEngine;

public class Tunnel : WaypontManager
{
    [SerializeField]
    private Waypoint[] digWaypoints;
    [SerializeField]
    private Waypoint[] cartWaypoints;
    [SerializeField] GameObject miner;
    List<Worker> workers = new List<Worker>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Worker go = Instantiate(miner, cartWaypoints[0].transform.position, Quaternion.identity).GetComponent<Worker>();
            go.workingTunnel = this;
            workers.Add(go);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FindJobToWorker(Worker worker)
    {
        if(worker.currentWaypoint == null && worker.waypoints.Count == 0)
        {
            //worker.waypoints.Enqueue(digWaypoints);
            GetWaypoints(worker);
        }
    }
    

}
