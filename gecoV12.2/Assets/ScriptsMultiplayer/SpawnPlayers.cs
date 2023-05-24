using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject playerObject = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        GameObject cameraObject = Instantiate(cameraPrefab, playerObject.transform.position, Quaternion.identity);
        cameraObject.GetComponent<CameraController>().SetTarget(playerObject.transform);
    }
}
