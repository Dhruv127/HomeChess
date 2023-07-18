using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplate : MonoBehaviour
{
    public GameObject controller;
    GameObject reference = null;
    public bool attack = false;
    int matrixX;
    int matrixY;

    // Start is called before the first frame update
   public  void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if(attack)
        {
            GameObject cp = controller.GetComponent<game>().GetPosition(matrixX, matrixY);
            if (cp.name == "white_king") controller.GetComponent<game>().Winner(game.player2namestr);
            if (cp.name == "black_king") controller.GetComponent<game>().Winner(game.player1namestr);

            Destroy(cp);
        }
        
        controller.GetComponent<game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(),
            reference.GetComponent<Chessman>().GetYBoard());
    

        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().Setcoords();

        controller.GetComponent<game>().SetPosition(reference);
        controller.GetComponent<game>().NextTurn();

       reference.GetComponent<Chessman>().DestroyMovePlates();
    }
    public void SetCoords(int  x, int y)
    {
        matrixX = x;
        matrixY = y;
       
    }
    public void SetReference(GameObject obj)
    {
        reference = obj;
    }
    public GameObject GetReference()
    {
        return reference;
    }
    
}
