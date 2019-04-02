using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour {
    //  Variable for Health UI
    public Sprite[] HeartSprites;
    public Image HealthUI;
    public GameScript readHealth;

    //  Gain access to Script
    private void Start()
    {
        readHealth = GameObject.Find("GameManager").GetComponent<GameScript>();
    }
    //  Display Array Image according to Control.health integar variable
    private void Update()
    {
        HealthUI.sprite = HeartSprites[(readHealth.health)-1];
    }

}
