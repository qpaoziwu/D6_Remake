using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wikipedia : MonoBehaviour
{
    public int played = 0;
    public int won = 0;
    public int lost = 0;
    public int winStreak = 0;
    public int bestStreak = 0;
    public int maxChain = 0;
    public int highScore = 0;
    public int winPercent = 0;


    public Text playedText;
    public Text wonText;
    public Text lostText;
    public Text winSteakText;
    public Text bestStreakText;
    public Text maxChainText;
    public Text highScoreText;
    public Text winPercentText;

    private void Update()
    {
        uploadScore();
    }
    public void uploadScore()
    {

        playedText.text = played.ToString();
        wonText.text = won.ToString();
        lostText.text = lost.ToString();
        winSteakText.text = winStreak.ToString();
        bestStreakText.text = bestStreak.ToString();
        maxChainText.text = maxChain.ToString();
        highScoreText.text = highScore.ToString();
        winPercentText.text = winPercent.ToString();

    }







}
