using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject dirtPrefab;

    public Transform spawnPoint;

    private GameObject _newWall;
    private Transform _dirtyWindows;

    public void SpawnWall()
    {
        _newWall = GameObject.Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity, transform);
        _newWall.GetComponent<Wall>().manager = this;
        _dirtyWindows = _newWall.transform.GetChild(Random.Range(0, _newWall.transform.childCount));
        GameObject.Instantiate(dirtPrefab, new Vector3(_dirtyWindows.position.x, _dirtyWindows.position.y, -1), Quaternion.identity, _dirtyWindows);
    }
}
