using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class Play : MonoBehaviour
{
    public TMP_InputField player1;
    public TMP_InputField player2;
    // Start is called before the first frame update
    public void play()
    {
        game.player1namestr = player1.text;
        game.player2namestr = player2.text;

        SceneManager.LoadScene("game");
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("startscene");
    }
}
