using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CiviliansSpawner : MonoBehaviour
{
    [SerializeField] private int maxCivilians;

    [SerializeField] private SpawnAreaHandler spawnAreaHandler;
    [SerializeField] private GameObject civilianPrefab;

    [ReadOnly][SerializeField] private List<GameObject> civiliansList;
    public Transform GetRandomCivilian => civiliansList[Random.Range(0, civiliansList.Count)].transform;

    public static UnityAction<GameObject> DestroyACivilian = default;

    private void OnEnable()
    {
        DestroyACivilian += HandleDestroyACivilian;
    }

    private void OnDisable()
    {
        DestroyACivilian -= HandleDestroyACivilian;
    }

    private void HandleDestroyACivilian(GameObject _civilian)
    {
        for (int i = 0; i < civiliansList.Count; i++)
        {
            if (civiliansList[i] == _civilian)
            {
                Destroy(civiliansList[i]);
                civiliansList.RemoveAt(i);
                break;
            }
        }
    }

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
