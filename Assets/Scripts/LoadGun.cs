using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGun : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public Transform spawnPoint;

    private void Start()
    {
        int selectedGun = PlayerPrefs.GetInt("selectedGun");
        GameObject prefab = gunPrefabs[selectedGun];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
