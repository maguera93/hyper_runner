using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Game;

public class Player : MonoBehaviour
{
    private const int MAX_SOLDIERS = 100;

    [SerializeField] private GameObject soldierPrefab;

    private float speed;
    private float radius = 0.5f;
    private Vector3 direction;
    private Transform cachedTransform;
    private GameObject[] soldiers;

    private PlayerModel model;

    public PlayerModel Model { get => model; }

    public void Setup(PlayerModel playerModel)
    {
        model = playerModel;
        speed = model.Speed;
        direction = Vector3.forward;
        cachedTransform = transform;

        SpawnSoldiers();
        AddSoldiers(model.Soldiers);
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        MouseDirection();
        if (Input.GetKeyDown(KeyCode.E))
            AddSoldiers(5);
        else if (Input.GetKeyDown(KeyCode.Q))
            GetDamage(5);

#else
        TouchDirection();
#endif

        cachedTransform.Translate(direction * speed * Time.deltaTime);
    }


    #region Movement
    private void MouseDirection()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            direction.x = worldPosition.x - cachedTransform.position.x;
        }
        else
        {
            direction.x = 0;
        }
    }

    private void TouchDirection()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            direction.x = pos.x - cachedTransform.position.x;
        }
    }
    #endregion

    #region Soldiers
    private void SpawnSoldiers()
    {
        soldiers = new GameObject[MAX_SOLDIERS];

        for (int i = 0; i < MAX_SOLDIERS; i++)
        {
            Vector2 circPos = Random.insideUnitCircle * radius;

            Vector3 position = new Vector3(circPos.x, 0.2f, circPos.y);

            GameObject go = Instantiate(soldierPrefab, position, Quaternion.identity, cachedTransform);
            soldiers[i] = go;
            go.SetActive(false);
        }
    }

    private void AddSoldiers(int addedSoldiers)
    {
        if (model.Soldiers + addedSoldiers >= MAX_SOLDIERS)
            return;

        for (int i = model.Soldiers; i < addedSoldiers + model.Soldiers; i++)
        {
            soldiers[i].SetActive(true);
        }

        model.AddSoldiers(addedSoldiers);
    }

    private void GetDamage(int damage)
    {
        if (model.Soldiers - damage <= 0)
            return;

        for (int i = model.Soldiers; i > model.Soldiers - damage; i--)
        {
            soldiers[i].SetActive(false);
        }

        model.GetDamage(damage);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        ITouchable touched = other.GetComponent<ITouchable>();

        if (other.CompareTag("Hazard"))
        {
            GetDamage(touched.value);
        }
    }
}
