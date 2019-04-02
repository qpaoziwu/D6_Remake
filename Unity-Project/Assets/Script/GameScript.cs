using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {
    public GameObject Dice;
    public Wikipedia wiki;
    public DicePrefeb Player;


    //Creating variables for the system///////////////////////////////////////////////
    public bool gameRunning = true;
    public int rowLength = 5;
    public int health = 7;
    public int score = 0;
    public int targetScore = 50;
    public int chain = 0;
    public int maxChain = 0;
    public Text scoreText;
    public Text chainText;
    public Text win;
    public Text maxChainText;

    //Creating variables to store highscore etc.//////////////////////////////////////
    public int played;
    public int won;
    public int lost;
    public int winStreak;
    public int bestStreak;
    public int highScore;
    public int winPercent;

    //Creating arrays for 2 rows of dice//////////////////////////////////////////////
    public DicePrefeb[] aRow;
    public DicePrefeb[] bRow;

    //Creating variables to store current dice value//////////////////////////////////
    public int aRowNumber;
    public int aRowColor;
    public int bRowNumber;
    public int bRowColor;
    public int PlayerNumber;
    public int PlayerColor;
    public int thisindex;
    public int thatindex;



    //The array creates on awake so it can pull value from rowLength//////////////////
    void Awake ()
    {   wiki = GameObject.Find("Wikipedia").GetComponent<Wikipedia>();
        Player = GameObject.Find("Player").GetComponent<DicePrefeb>();
        
        aRow = new DicePrefeb[rowLength];
        bRow = new DicePrefeb[rowLength];
        readWiki();
        Populate();
    }

    //Reset
    void Start()
    {    
        health = 7;
        score = 0;
        chain = 0;
    }

    //Instantiation for the 2 rows of dice////////////////////////////////////////////
    void Populate()
    {
        for (int a = 0; a < aRow.Length; a++)
        {
            int thatindex = a;
            
            GameObject DicePrefab = Instantiate(Dice, new Vector3(a - (rowLength - 1) / 2f, 0f, 0f), Quaternion.identity) as GameObject;
            aRow[a] = DicePrefab.GetComponent<DicePrefeb>();

            aRow[a].name = "a" + thatindex;
            DicePrefab.tag = "aRow";
            aRow[a].index = thatindex;
        }

        for (int b = 0; b < bRow.Length; b++)
        {
            int bb = b;

            GameObject DicePrefab = Instantiate(Dice, new Vector3(b - (rowLength - 1) / 2f, 1f, 0f), Quaternion.identity) as GameObject;
            bRow[b] = DicePrefab.GetComponent<DicePrefeb>();

            bRow[b].name = "b" + bb;
            DicePrefab.tag = "bRow";
            bRow[b].index = bb;
        }
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        chainText.text = chain.ToString();
    //  maxChainText.text = maxChain.ToString();
    }



    //Pass value to Player Object////////////////////////////////
    public void copyARow(int x)
    {
        //if statement

        if (gameRunning)
        {
            PlayerNumber = aRowNumber;
            PlayerColor = aRowColor;
            updatePlayer();
            addScore();
            copyBRow();
            thisindex = x;
        }
    }
    //Contantly update the render of player Object///////////////////
    public void updatePlayer()
    {
        Player.empty = false;
        Player.number = PlayerNumber;
        Player.colorNumber = PlayerColor;
    }

    public void copyBRow()
    {
        aRowNumber = bRowNumber;
        aRowColor = bRowColor;

    }

    public void dropDice() {
        if (health == 1)
        {
            checkWin();
            Debug.Log("wow");
        }
        chain = 0;
        if (health > 1)
        {
            health -= 1;
        }

    }

    //Add score and chain score///////////////////////////////////////////////////////
    public void addScore()
    {
        score += 1;
        chain += 1;

        if (chain > maxChain)
        {
            maxChain = chain;
        }

    }
    public void checkWin() {
       
        gameRunning = false;

        if (score >= targetScore)
        { 
            win.text = "You Win!";
            won += 1;
            played += 1;
            if (score > highScore)
            {
                highScore = score;
            }
            if (won > winStreak)
            {
                winStreak = won;
                if (winStreak > bestStreak)
                {
                    bestStreak = winStreak;
                }
            }
        }   


        else if(score < targetScore) {
            win.text = "Game Over!";
            lost += 1;
            winStreak = 0;
            played += 1;
            if (score > highScore)
            {
                highScore = score;
            }
        }
        winPercent = (int)((double)won /played * 100);
        uploadStats();
        



    }
    public void readWiki()
    {
        winPercent = wiki.winPercent;
        played = wiki.played;
        won = wiki.won;
        lost = wiki.lost;
        winStreak = wiki.winStreak;
        bestStreak = wiki.bestStreak;
        maxChain = wiki.maxChain;
        highScore = wiki.highScore;

    }
    public void uploadStats() {



    wiki.played = played;
    wiki.won = won;
    wiki.lost = lost;
    wiki.winStreak = winStreak;
    wiki.bestStreak = bestStreak;
    wiki.maxChain = maxChain;
    wiki.highScore = highScore;
    wiki.winPercent = winPercent;

}


}



















           ////////////////////////////
      //////////////////////////////////////
   ///////////////////////////////////////////
  ///////    WELCOME TO THE GRAVDYARD    ////////
////////                                  ///////
//////////////////////////////////////////////////
//////                                         /////
//////                                         /////
//////                                         /////
//////   UNUSABLE CODES LIE BELOW              /////
//////                                         /////
//////                                 x_x     /////
//////                                         /////
////////////////////////////////////////////////////
////////////////////////////////////////////////////
////////////////////////////////////////////////////
////////////////////////////////////////////////////     
////////////////////////////////////////////////////          V
////////////////////////////////////////////////////         V 
////////////////////////////////////////////////////    V    V    V
////////////////////////////////////////////////////    V   V   V
////////////////////////////////////////////////////    V V  VV
//____________________________________________________ __VVV____________________________
//    Debug.Log(Player.number);
//if ()
//(Player.number > 6 || aRow[i].color == Player.color || (aRow[i].number - Player.number == 1f) || (Player.number - aRow[i].number == 5f))
//{
//  if (aRow[i].index == bRow[i].index)
//   {
//      Debug.Log("hi u fuk");
//      bRow[i].randomize();

//  }
// Debug.Log(bRow[thisindex]);
//     Player.number = aRow[thisindex].number;
//    Player.colorNumber = aRow[thisindex].colorNumber;


//    aRow[thisindex].number = bRow[thisindex].number;
//    aRow[thisindex].colorNumber = bRow[thisindex].colorNumber;

//}

// public void copyBRow()
// {
//    aRowColor;
//    aRowNumber;
//
//}