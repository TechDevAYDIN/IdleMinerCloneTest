using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDA.NPC
{
    public class Worker : NPCBehaviours
    {
        [SerializeField]
        protected NpcType workerType = NpcType.None;

        public Tunnel workingTunnel;
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame

        public override void IdleUpdate()
        {
            base.IdleUpdate();
            if (currentWaypoint == null)
            {
                workingTunnel.GetWaypoints(this);
                currentState = State.Waiting;
            }
                
            else
                currentState = State.Moving;
        }
        public override void WaitingUpdate()
        {
            base.WaitingUpdate();
            
        }
        public override void MovingUpdate()
        {
            base.MovingUpdate();
            if(Vector3.Distance(transform.position, currentWaypoint.transform.position)> .15f)
            {
                agent.SetDestination(currentWaypoint.transform.position);
            }
            else
            {
                currentState = State.Performing;
            }
        }
    }
}