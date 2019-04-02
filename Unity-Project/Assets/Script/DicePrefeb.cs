using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePrefeb : MonoBehaviour {

    //Creating Array for all colors and sprites/////////////////////////////////////////////////////////////
    public Color[] colors = new Color[7];
    public int[] diceNumber = new int[7];
    public Sprite[] diceImage = new Sprite[7];

    //Creating variables to store die color and sprite//////////////////////////////////////////////////////
    public Color color;
    public int colorNumber;
    public int number;
    public int aRowColor;
    public int aRowNumber;
    public int bRowColor;
    public int bRowNumber;
    public bool isPlayer = false;
    public bool aRow = false;
    public bool bRow = false;
    public bool empty = true;

    //Index is the index number of the array object/////////////////////////////////////////////////////////
    public int index;

    //Creating references for components////////////////////////////////////////////////////////////////////
    public GameObject GameObject;
    public GameScript gameScript;
    public BoxCollider2D box;
    SpriteRenderer spriteComponent;




    //Set array values when game starts/////////////////////////////////////////////////////////////////////
    void Awake()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        SetArray();
        spriteComponent = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }


    //Generate die color and number when spawn//////////////////////////////////////////////////////////////
    void Start()
    {
        randomize();
        catagorize();
        checkPlayer();
        drawMe();
        passValues();
    }

    void Update()
    {
        catagorize();
        drawMe();

    }

    //Data for colors and sprites///////////////////////////////////////////////////////////////////////////
    void SetArray()
    {
        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.gray;
        colors[4] = Color.yellow;
        colors[5] = Color.magenta;
        colors[6] = Color.white;

        diceNumber[0] = 1;
        diceNumber[1] = 2;
        diceNumber[2] = 3;
        diceNumber[3] = 4;
        diceNumber[4] = 5;
        diceNumber[5] = 6;
        diceNumber[6] = 7;

    }

    void OnMouseDown()
    {
        loop(index);
    }


    void loop(int x)
    {

        if (gameScript.gameRunning == true)
        {
            if (isPlayer&&!empty)
            {
                nullMe();
            }

            if (aRow)
            {

                if (gameScript.Player.number == 6 ||                  //  If player is nullified

                    number - gameScript.Player.number == 1 ||         //  Dice# is larger than 1

                    number == 0 && gameScript.Player.number == 5 ||       //  Dice# 6 to 1

                    colorNumber == gameScript.Player.colorNumber)   //  If color matches
                {

                    //Debug.Log(number);

                    aRowNumber = number;
                    aRowColor = colorNumber;
                    gameScript.aRowColor = aRowColor;
                    gameScript.aRowNumber = aRowNumber;
                    gameScript.copyARow(x);

                    //Debug.Log("Before =" + gameScript.bRow[x]);
                    bRow = true;

                }

                if (bRow)
                {
                    gameScript.aRow[x].number = gameScript.bRow[x].number;
                    //Debug.Log(gameScript.bRow[x].number);
                    gameScript.aRow[x].colorNumber = gameScript.bRow[x].colorNumber;
                    //gameScript.bRow[x].randomize();
                    gameScript.bRow[x].number = Random.Range(0, 5);
                    gameScript.bRow[x].colorNumber = Random.Range(0, 5);

                    //Debug.Log("After =" + gameScript.bRow[x].number);
                    bRow = false;
                }

            }

        }

    }

    //Pass value of Prefab object////////////////////////////
    public void passValues()
    {
        if (aRow)
        {
        aRowColor = colorNumber;
        gameScript.aRowColor = aRowColor;
        aRowNumber = number;
        gameScript.aRowNumber = aRowNumber;
        }
        if (bRow)
        { 
        bRowColor = colorNumber;
        gameScript.bRowColor = bRowColor;
        bRowNumber = number;
        gameScript.bRowNumber = bRowNumber;
        }
    }

    
    //Update the visual in update();/////////////////////////////////////////////////////////////////////////
    public void drawMe()
    {
        
        spriteComponent.sprite = diceImage[number];
      //  color.a = 0.5f;
        color = colors[colorNumber];
        spriteComponent.color = color;

    }    
    
    
    //Get a random number and color within the array length//////////////////////////////////////////////////
    public void randomize()
    {   
            colorNumber = (Random.Range(0, 5));
            number = diceNumber[Random.Range(0, 5)];
            color = colors[colorNumber];

    }


    //Function to check if the dice is player/////////////////////////////////////////////////////////////////
    void catagorize() {
        if (GameObject.tag == "Player")
        {
            isPlayer = true; 
        }
        if (GameObject.tag == "aRow")
        {
            aRow = true;
        }
        if (GameObject.tag == "bRow")
        {
            bRow = true;
        }
    }


    //Nullify player when called/////////////////////////////////////////////////////////////////////////////
    void checkPlayer()
    {
        if (GameObject.tag == "Player")
        {
            nullMe();

        }
    }

    //Nullify the values so the center is empty///////////////////////////////////////////////////////////////
    void nullMe()
    {
        empty = true;
        gameScript.dropDice();
        colorNumber = 6;
        number = 6;
        color = colors[colorNumber];
    }

    public void reset()
    {

            gameScript.score = 0;
            gameScript.health = 7;
            gameScript.chain = 0;
            gameScript.gameRunning = true;
            gameScript.win.text = (" ");

            for (int a = 0; a < gameScript.rowLength; a++)
            {
            gameScript.aRow[a].randomize();
            gameScript.bRow[a].randomize();
            }

            if (GameObject.tag == "Player")
             {
            empty = true;
            colorNumber = 6;
            number = 6;
            color = colors[colorNumber];
             }
    }

}


/*
        if (isPlayer)
        {
            empty = true;
            colorNumber = 6;
            number = 6;
            color = colors[colorNumber];
        }
        else {


        }
                    gameScript.aRow[a].colorNumber = (Random.Range(0, 5));
                gameScript.aRow[a].number = diceNumber[Random.Range(0, 5)];
                gameScript.aRow[a].color = colors[colorNumber];
                gameScript.bRow[a].colorNumber = (Random.Range(0, 5));
                gameScript.bRow[a].number = diceNumber[Random.Range(0, 5)];
                gameScript.bRow[a].color = colors[colorNumber];

    */


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

//  number = gameScript.bRow[x].number;
//  colorNumber = gameScript.bRow[x].colorNumber;
//      Debug.Log("FirstColor =" + gameScript.aRowColor);

//   void test()
//   {

//           colorNumber = bRowColor;
//           number = bRowNumber;
//       if (bRow) {

//            gameScript.copyBRow();
//            bRowColor = (Random.Range(0, 5));
//            bRowNumber = (Random.Range(0, 5));
//            bRowColor = colorNumber;
//            bRowNumber = number;
//            gameScript.bRowColor = bRowColor;
//            gameScript.bRowNumber = bRowNumber;
//        }

//           colorNumber = gameScript.bRowColor;
//           number = gameScript.bRowNumber;
//           colorNumber = bRowNumber;
//           number = bRowColor;
//           gameScript.bRowColor = gameScript.aRowColor;
//           gameScript.bRowNumber = gameScript.aRowNumber;

//    }

//    void checkBRow() {
//
//       if (GameObject.tag == "bRow")
//       {
//
//            randomize();
//       }
//
//   }

//        gameScript.rowB(index);
//            randomize();
//        if (bRow)
//       {
//
//      }
//  gameScript.dropDice();



//    if ()
//       {

//       randomize();
//   }

//   public void drawARow() {
//       gameScript.aRow[index].number = gameScript.bRow[index].number;
//      gameScript.aRow[index].colorNumber = gameScript.bRow[index].colorNumber;
//       drawMe();
//   
//