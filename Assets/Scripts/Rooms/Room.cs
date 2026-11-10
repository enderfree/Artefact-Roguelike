using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    // Fields
    [SerializeField] private RoomNames _name;
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private List<Transform> _enemySpawns;

    // Getters and Setters
    public virtual RoomNames RoomName
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public virtual Transform PlayerSpawn
    {
        get
        {
            return _playerSpawn;
        }
        set
        {
            _playerSpawn = value;
        }
    }

    public virtual List<Transform> EnemySpawns
    {
        get
        {
            return _enemySpawns;
        }
    }
}
