using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject PlayerCamera;
    public GameObject GameUI;
    public GameObject MenuUI;
    public GameObject StatUI;
    public GameObject HowUI;
    public GameObject Play;
    public GameObject Stats;
    public GameObject How;
    public BoxCollider2D PlayBox;
    public BoxCollider2D StatsBox;
    public BoxCollider2D HowBox;

    float direction;



    private void Update()
    {

    }
    void Start () {
        direction = 100;
        GameUI.SetActive(false);
        MenuUI.SetActive(true);
        StatUI.SetActive(false);
        HowUI.SetActive(false);
    }

    private void OnMouseDown()
    {


        if (tag == ("Play")) {
            
            GameUI.SetActive(true);
            MenuUI.SetActive(false);
            StatUI.SetActive(false);
            HowUI.SetActive(false);

            direction = 0;
            PlayerCamera.transform.position = new Vector3(direction, 0f, -100);

        }

        if (tag == ("How"))
        {
            direction = 50;
            GameUI.SetActive(false);
            MenuUI.SetActive(false);
            StatUI.SetActive(false);
            HowUI.SetActive(true);

            PlayerCamera.transform.position = new Vector3(direction, 0f, -100);

        }
        if (tag == ("Stats"))
        {
            direction = 75;
            GameUI.SetActive(false);
            MenuUI.SetActive(false);
            StatUI.SetActive(true);
            HowUI.SetActive(false);

            PlayerCamera.transform.position = new Vector3(direction, 0f, -100);

        }
        if (tag == ("Menu"))
        {
            if (PlayerCamera.transform.position.x != 25)
            {
                
                GameUI.SetActive(false);
                MenuUI.SetActive(true);
                StatUI.SetActive(false);
                HowUI.SetActive(false);

                PlayerCamera.transform.position = new Vector3(25, 0f, -100);

            }
            else if (PlayerCamera.transform.position.x == 25)
            {

                GameUI.SetActive(true);
                MenuUI.SetActive(false);
                StatUI.SetActive(false);
                HowUI.SetActive(false);

                PlayerCamera.transform.position = new Vector3(direction, 0f, -100);

            }
        }

        if (direction >= 100)
        {
            GameUI.SetActive(false);
            MenuUI.SetActive(true);
            StatUI.SetActive(false);
            HowUI.SetActive(false);

            PlayerCamera.transform.position = new Vector3(25, 0f, -100);
        }
    }





}
