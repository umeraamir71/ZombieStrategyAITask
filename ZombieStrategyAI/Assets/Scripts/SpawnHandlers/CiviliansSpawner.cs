using System.Collections.Generic;
using UnityEngine;

public class CiviliansSpawner : MonoBehaviour
{
    [SerializeField] private int maxCivilians;

    [SerializeField] private SpawnAreaHandler spawnAreaHandler;
    [SerializeField] private GameObject civilianPrefab;

    [ReadOnly][SerializeField] private List<GameObject> civiliansList;

    private void SpawnCivilian()
    {
        civiliansList.Add(Instantiate(civilianPrefab, spawnAreaHandler.GetSpawnPoint(), Quaternion.identity, transform));
    }

    private void FixedUpdate()
    {
        if (civiliansList.Count < maxCivilians)
            SpawnCivilian();
    }
}
