using UnityEngine;
using System.Collections.Generic;
using System;

public class RoomManager : MonoBehaviour
{
    // Fields
    [SerializeField] private List<GameObject> _roomPrefabs;

    public Dictionary<RoomNames, GameObject> RoomPrefabs = new Dictionary<RoomNames, GameObject>();

    // Functions
    public void Init()
    {
        foreach (GameObject prefab in _roomPrefabs)
        {
            RoomPrefabs.Add(prefab.GetComponent<Room>().RoomName, prefab);
        }
    }
}
