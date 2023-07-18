using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class game : MonoBehaviour
{
    public static string player1namestr;
    public TMP_Text player1name;
    public static string player2namestr;
    public TMP_Text player2name;
    public TMP_Text winnerText;
        public TMP_Text Restart;
    public GameObject button ;
    public GameObject chesspiece;
    private string currentPlayer = "white";
    private bool gameover = false;
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];
    // Start is called before the first frame update
    
    void Start()
    {
        player1name.text = player1namestr;
        player2name.text = player2namestr;
        playerWhite = new GameObject[]
        {
           // Create("white_king",-0.57f,-3.86f),Create("white_queen",0.52f,-3.86f),Create("white_rook",-3.93f,-3.86f),Create("white_rook",3.88f,-3.86f),
            //Create("white_knight",-2.81f,-3.86f),Create("white_knight",2.73f,-3.86f),Create("white_bishop",1.6f,-3.86f),Create("white_bishop",-1.66f,-3.86f),
            //Create("white_pawn",3.88f,-2.75f),Create("white_pawn",2.73f,-2.75f),
            //Create("white_pawn",1.6f,-2.75f),Create("white_pawn",0.52f,-2.75f),Create("white_pawn",-0.57f,-2.75f),
            //Create("white_pawn",-1.66f,-2.75f),Create("white_pawn",-2.81f,-2.75f),Create("white_pawn",-3.93f,-2.75f)
             Create("white_king",4,0),Create("white_queen",3,0),Create("white_rook",0,0),Create("white_rook",7,0),
            Create("white_knight",6,0),Create("white_knight",1,0),Create("white_bishop",5,0),Create("white_bishop",2,0),
            Create("white_pawn",7,1),Create("white_pawn",6,1),
            Create("white_pawn",1,1),Create("white_pawn",0,1),Create("white_pawn",2,1),
            Create("white_pawn",3,1),Create("white_pawn",4,1),Create("white_pawn",5,1)

        };
        playerBlack = new GameObject[]
        {
            //Create("black_king",-0.57f,3.88f),Create("black_queen",0.52f,3.88f),Create("black_rook",-3.93f,3.88f),Create("black_rook",3.88f,3.88f),
            //Create("black_knight",-2.81f,3.88f),Create("black_knight",2.73f,3.88f),Create("black_bishop",1.6f,3.88f),Create("black_bishop",-1.66f,3.88f), 
            //Create("black_pawn",3.88f,2.79f),Create("black_pawn",2.73f,2.79f),Create("black_pawn",1.6f,2.79f),Create("black_pawn",0.52f,2.79f),
            //Create("black_pawn",-0.57f,2.79f),Create("black_pawn",-1.66f,2.79f),Create("black_pawn",-2.81f,2.79f),Create("black_pawn",-3.93f,2.79f)
            Create("black_king",4,7),Create("black_queen",3,7),Create("black_rook",0,7),Create("black_rook",7,7),
            Create("black_knight",6,7),Create("black_knight",1,7),Create("black_bishop",2,7),Create("black_bishop",5,7),
            Create("black_pawn",0,6),Create("black_pawn",1,6),Create("black_pawn",2,6),Create("black_pawn",3,6),
            Create("black_pawn",4,6),Create("black_pawn",5,6),Create("black_pawn",6,6),Create("black_pawn",7,6)
        };

        for(int i=0;i<playerBlack.Length;i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name,int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm =obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }
    public void SetPosition(GameObject obj)
    {
       Chessman cm = obj.GetComponent<Chessman>();
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
    public void SetPositionEmpty (int x,int y)
    {
        positions[x, y] = null;
    }
    public GameObject GetPosition(int x,int y)
    {
        return positions[x, y];
    }
    public bool PositionOnBoard(int x,int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }
    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }
    public bool IsGameOver()
    {
        return gameover;
    }
    public void NextTurn()
    {
        if(currentPlayer=="white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
    }

    public void Update()
    {
        if (gameover == true && Input.GetMouseButtonDown(0))
        {
            gameover = false;
            SceneManager.LoadScene("game");
        }
    }
    public void Winner(string playerWinner)
    {
        gameover = true;
        //GameObject.FindGameObjectsWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = "truea";
        winnerText.enabled = true;
        winnerText.text = playerWinner + " is the winner";

        Restart.enabled = true ;


    }
}
