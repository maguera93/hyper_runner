using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Game;

public class RecruitSoldier : MonoBehaviour, ITouchable
{
    [SerializeField] private int soldiers;
    [SerializeField] private GameObject soldierPrefab;

    private float radius = 0.2f;

    public int value { get => soldiers; set => soldiers = value; }

    private void Start()
    {
        SpawnSoldiers();
    }

    private void SpawnSoldiers()
    {
        for (int i = 0; i < soldiers; i++)
        {
            Vector2 circPos = Random.insideUnitCircle * radius;

            Vector3 position = new Vector3(circPos.x, 0.2f, circPos.y) + transform.position;

            GameObject go = Instantiate(soldierPrefab, position, Quaternion.identity, transform);
        }
    }

    public void OnTouch()
    {
        gameObject.SetActive(false);
    }
}
