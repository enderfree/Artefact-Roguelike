using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playtestPopulation;

    public void SpawnPlaytestEnemies(Room activeRoom)
    {
        foreach (Transform enemySpawm in activeRoom.EnemySpawns)
        {
            if (_playtestPopulation.Count == 0) break;

            int rand = Random.Range(0, _playtestPopulation.Count);
            Instantiate(_playtestPopulation[rand], enemySpawm.position, enemySpawm.rotation);
            _playtestPopulation.RemoveAt(rand);
        }
    }
}
