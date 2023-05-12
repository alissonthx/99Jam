using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private GameObject vcam;
    [SerializeField]
    private int currentRoom;    
    public int _currentRoom => currentRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            vcam.SetActive(true);
            string roomName = gameObject.name;
            char roomNumber = roomName.Substring(roomName.Length - 1, 1)[0];
            currentRoom = int.Parse(roomNumber.ToString());
            // Debug.Log("Player entered room " + currentRoom);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            vcam.SetActive(false);
        }
    }
}
