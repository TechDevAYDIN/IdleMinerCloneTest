using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TDA.NPC
{
    public class Waypoint : MonoBehaviour
    {
        // �zellikler
        public bool isOccupied; // Waypointin dolu olup olmad���n� belirten boolean de�i�keni
        public NPCBehaviours occupiedBy; // Waypointin Kim taraf�ndan dolduruldu�unu g�steren de�i�ken.

        [SerializeField] // Edit�rde g�r�n�r ve d�zenlenebilir yapmak i�in attribute ekle 
        public List<WaypointActions> actions; // Waypointe ula�an NPC'nin yapmas� gereken eylemleri i�eren liste


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