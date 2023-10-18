using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TDA.NPC
{
    public class Waypoint : MonoBehaviour
    {
        // Özellikler
        public bool isOccupied; // Waypointin dolu olup olmadýðýný belirten boolean deðiþkeni
        public NPCBehaviours occupiedBy; // Waypointin Kim tarafýndan doldurulduðunu gösteren deðiþken.

        [SerializeField] // Editörde görünür ve düzenlenebilir yapmak için attribute ekle 
        public List<WaypointActions> actions; // Waypointe ulaþan NPC'nin yapmasý gereken eylemleri içeren liste


        public void SetOccupied()
        {
            if (!isOccupied)
                isOccupied = true;
        }
        public void SetFree()
        {
            if (isOccupied)
                isOccupied = false;
        }
    }
}