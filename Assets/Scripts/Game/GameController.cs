using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerConfig playerConfig;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private Player player;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject go = Instantiate(playerPrefab, playerSpawn);
        virtualCamera.Follow = go.transform;
        player = go.GetComponent<Player>();
        player.Setup(new PlayerModel(playerConfig));
    }
}
