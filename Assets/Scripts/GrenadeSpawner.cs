using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _grenadePrefab;

    private void Start()
    {
        SpawnGrenade();
    }

    private void SpawnGrenade()
    {
        GameObject go = Instantiate(_grenadePrefab, transform.position, Quaternion.identity);
        Grenade grenade = go.GetComponent<Grenade>();
        grenade.OnExploded += SpawnGrenade;
    }
}
