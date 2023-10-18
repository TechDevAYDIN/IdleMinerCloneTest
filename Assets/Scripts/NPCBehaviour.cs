using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

namespace TDA.NPC

{
    public abstract class NPCBehaviours : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Animator animator;
        public List<Waypoint> waypoints; // Waypoint Queue
        public Waypoint currentWaypoint;
        public UnityEvent actions; // To-do list
        public State currentState = State.Idle;

        public Waypoint CurrentWatpoint 
        {
            get
            {
                return currentWaypoint;
            }
            private set
            {
                currentWaypoint = value;
                WaypointChanged();
            }
        }
        public enum State
        {
            Idle,
            Moving,
            Waiting,
            Performing
        }
        //public delegate void StateDelegate(State state);

        public virtual void Start()
        {
            // Initialization procedures
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        public virtual void Update()
        {
            // Manage NPC behavior based on its current state here
            switch (currentState)
            {
                case State.Idle:
                    // Idle behavior
                    IdleUpdate();
                    break;

                case State.Moving:
                    // Moving behavior
                    MovingUpdate();
                    break;

                case State.Waiting:
                    // Waiting behavior
                    WaitingUpdate();
                    break;

                case State.Performing:
                    // Performing behavior
                    PerformingUpdate();
                    break;
                default:
                    break;
            }
        }
        public virtual void IdleUpdate()
        {

        }
        public virtual void MovingUpdate()
        {

        }
        public virtual void WaitingUpdate()
        {

        }
        public virtual void PerformingUpdate()
        {

        }
        public void MoveToNextWaypoint()
        {
            // Move to the next waypoint
            if (waypoints.Count > 0)
            {
                //currentWaypoint = waypoints.Dequeue();
                agent.SetDestination(currentWaypoint.transform.position);
                currentState = State.Moving;
            }
            else
            {
                // Actions to take when there are no waypoints left
                currentState = State.Idle;
            }
        }
        private void WaypointChanged()
        {

        } 
        public void PerformAction()
        {
            // Start performing the specified action
            //actions.Invoke();
            currentState = State.Performing;
        }
        public void MoveForward()
        {
            agent.SetDestination(transform.forward);
        } 
    }
    public enum NpcType
    {
        Miner,
        Carrier,
        None
    }
}