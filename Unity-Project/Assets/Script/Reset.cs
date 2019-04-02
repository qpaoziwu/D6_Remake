using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Reset : MonoBehaviour
{
    public DicePrefeb Player;
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<DicePrefeb>();
    }
    public void RestartGame()
    {
        Player.reset();

    }
    private void OnMouseDown()
    {
        RestartGame();
    }
}