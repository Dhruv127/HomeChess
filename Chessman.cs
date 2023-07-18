using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chessman : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private int xboard = -1;
    public int yboard = -1;
    public GameObject chesspiece;
    public GameObject moveplate;
    public GameObject controller ;
    public Sprite black_knight;
    public Sprite black_king;
    public Sprite black_queen;
    public Sprite black_bishop;
    public Sprite black_rook;
    public Sprite black_pawn;

    public Sprite white_knight;
    public Sprite white_king;
    public Sprite white_queen;
    public Sprite white_bishop;
    public Sprite white_rook;
    public Sprite white_pawn;
    bool con = true;
    private string player;
    private string rank = "one";
         private string hail="king";
    
    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        Setcoords();

        switch (this.name)
        {
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen;player = "black"; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; player = "black";rank = "king"; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop; player = "black"; break;
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; player = "black"; break;
            case "black_pawn":
                this.GetComponent<SpriteRenderer>().sprite = black_pawn; player = "black"; break;

                
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; player = "black"; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; player = "white"; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; player = "white"; rank = "king"; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop; player = "white"; break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; player = "white"; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; player = "white"; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; player = "white"; break;
        }
    }
    public void Activate2()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        

        switch (this.name)
        {
            
            case "black_pawn":
                this.GetComponent<SpriteRenderer>().sprite = black_queen; player = "black"; break;


            
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; player = "white"; break;
            
        }
    }

    public void Setcoords()
    {
        float x = xboard;
        float y = yboard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;



        this.transform.position = new Vector3(x, y, -1);
    }
    public int GetYBoard()
    {
        return yboard;
    }
    public int GetXBoard()
    {
        return xboard;
    }
    public void SetXBoard(int x)
    {
        xboard = x;
    }
    public void SetYBoard(int y)
    {
        yboard = y;
    }
    private void OnMouseUp()
    {
        if (!controller.GetComponent<game>().IsGameOver() && controller.GetComponent<game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();
            IntiateMovePlates();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] moveplates = GameObject.FindGameObjectsWithTag("Moveplate");

        for (int i = 0; i < moveplates.Length; i++)
        {
            Destroy(moveplates[i]);
        }
    }
    public void IntiateMovePlates()
    {
        switch (this.name)
        {
            case "black_queen":
            case "white_queen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, -1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                break;
            case "black_knight":
            case "white_knight":
                LMovePlate();
                break;
            case "black_rook":
            case "white_rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "black_bishop":
            case "white_bishop":
                LineMovePlate(1, -1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                break;
            case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;
            case "black_pawn":
                if(yboard==0||!con)
                {
                    
                    
                        black_pawn = black_queen;
                        Activate2();
                        Advancement(yboard);
                        con = false;
                    
                }
                if (yboard == 6&& con)
                {
                    StartPawnMovePlateBlack(xboard, yboard - 2);
                }
                if(con)
                PawnMovePlate(xboard, yboard - 1);
                
                break;
            case "white_pawn":
                if (yboard == 7 || !con)
                {
                    white_pawn = white_queen;
                    Activate2();
                    Advancement(yboard);
                    con = false;
                }
                if (yboard == 1&&con)
                {
                    StartPawnMovePlateWhite(xboard, yboard + 2);
                }
                if(con)
                PawnMovePlate(xboard, yboard + 1);
                
                 break;

        }
    }
    public void LineMovePlate(int xincrement, int yincremnet)
    {
        game sc = controller.GetComponent<game>();
        int x = xboard + xincrement;
        int y = yboard + yincremnet;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null &&rank != hail)
        {
            MovePlateSpawn(x, y);
            x += xincrement;
            y += yincremnet;
        }
        if(sc.PositionOnBoard(x,y)&&sc.GetPosition(x,y).GetComponent<Chessman>().player!=player&& rank != hail)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xboard + 1, yboard + 2);
        PointMovePlate(xboard - 1, yboard + 2);
        PointMovePlate(xboard + 1, yboard - 2);
        PointMovePlate(xboard - 2, yboard - 1);
        PointMovePlate(xboard - 1, yboard - 2);
        PointMovePlate(xboard + 2, yboard + 1);
        PointMovePlate(xboard - 2, yboard + 1);
        PointMovePlate(xboard + 2, yboard - 1);

    }

    public void SurroundMovePlate()
    {
        PointMovePlate_king(xboard, yboard + 1);
        PointMovePlate_king(xboard, yboard - 1);
        PointMovePlate_king(xboard - 1, yboard - 1);
        PointMovePlate_king(xboard - 1, yboard);
        PointMovePlate_king(xboard + 1, yboard);
        PointMovePlate_king(xboard + 1, yboard + 1);
        PointMovePlate_king(xboard - 1, yboard + 1);
        PointMovePlate_king(xboard + 1, yboard - 1);
    }
    public void PointMovePlate_king(int x, int y)
    {
        game sc = controller.GetComponent<game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null )
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }
    public void PointMovePlate(int x, int y)
    {
        game sc = controller.GetComponent<game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null&& rank != hail)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void Advancement (int yboard)
    {
        
        LineMovePlate(1, 0);
        LineMovePlate(0, 1);
        LineMovePlate(-1, 0);
        LineMovePlate(0, -1);
        LineMovePlate(1, 1);
        LineMovePlate(-1, -1);
        LineMovePlate(1, -1);
        LineMovePlate(-1, 1);
    }
    public void PawnMovePlate(int x, int y)
    {

        game sc = controller.GetComponent<game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null && rank != hail)
           {
                MovePlateSpawn(x, y);
            }

            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null &&
                 sc.GetPosition(x + 1, y).GetComponent<Chessman>().player!=player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null &&
                 sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }
    public void StartPawnMovePlateBlack(int x, int y)
    {
        game sc = controller.GetComponent<game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if (sc.PositionOnBoard(x + 1, y + 1) && sc.GetPosition(x + 1, y + 1) != null &&
                 sc.GetPosition(x + 1, y + 1).GetComponent<Chessman>().player != player )
            {
                MovePlateAttackSpawn(x + 1, y-1);
            }
            if (sc.PositionOnBoard(x - 1, y + 1) && sc.GetPosition(x - 1, y + 1) != null &&
                 sc.GetPosition(x - 1, y + 1).GetComponent<Chessman>().player != player )
            {
                MovePlateAttackSpawn(x - 1, y + 1);
            }
        }
    }


        public void StartPawnMovePlateWhite(int x, int y)
        {
            game sc = controller.GetComponent<game>();
            if (sc.PositionOnBoard(x, y))
            {
                if (sc.GetPosition(x, y) == null)
                {
                    MovePlateSpawn(x, y);
                }

                if (sc.PositionOnBoard(x + 1, y - 1) && sc.GetPosition(x + 1, y - 1) != null &&
                     sc.GetPosition(x + 1, y - 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(x + 1, y-1);
                }
          
            if (sc.PositionOnBoard(x - 1, y - 1) && sc.GetPosition(x - 1, y - 1) != null &&
                     sc.GetPosition(x - 1, y - 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(x - 1, y - 1);
                }
               
            }
        }

        public void MovePlateSpawn(int matrixX, int matrixY)
    {       
        {

            float x = matrixX;
            float y = matrixY;

            x *= 0.66f;
            y *= 0.66f;

            x += -2.3f;
            y += -2.3f;

            GameObject mp = Instantiate(moveplate, new Vector3(x, y, -3.0f), Quaternion.identity);
            moveplate mpScript = mp.GetComponent<moveplate>();
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }
        
    }

    public void MovePlateAttackSpawn_king(int matrixX, int matrixY)
    {
        {
            float x = matrixX;
            float y = matrixY;

            x *= 0.66f;
            y *= 0.66f;

            x += -2.3f;
            y += -2.3f;

            GameObject mp = Instantiate(moveplate, new Vector3(x, y, -3.0f), Quaternion.identity);
            moveplate mpScript = mp.GetComponent<moveplate>();
            mpScript.attack = true;
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }
        

    }
    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
       
        {
            float x = matrixX;
            float y = matrixY;

            x *= 0.66f;
            y *= 0.66f;

            x += -2.3f;
            y += -2.3f;

            GameObject mp = Instantiate(moveplate, new Vector3(x, y, -3.0f), Quaternion.identity);
            moveplate mpScript = mp.GetComponent<moveplate>();
            mpScript.attack = true;
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }
        

    }


    // Start is called before the first frame update
}