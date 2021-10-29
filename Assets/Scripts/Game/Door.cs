using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Game;
using TMPro;

public class Door : MonoBehaviour, ITouchable
{
    [SerializeField] private int requiredSoldiers;
    [SerializeField] private TextMeshPro soldiersText;

    public int value { get => requiredSoldiers; set => requiredSoldiers = value; }

    private void Start()
    {
        soldiersText.text = requiredSoldiers.ToString();
    }

    public void OnTouch()
    {
        gameObject.SetActive(false);
    }
}
