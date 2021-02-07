using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore01 = 0, playerScore02 = 0;
    public GUISkin theSkin;
    private GameObject theBall;

    private void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");

    }
    // Update is called once per frame
    public static void Score(string wallName)
    {
        if (wallName.Equals("rightWall")){
            playerScore01++;
        } else {
            playerScore02++;
        }
    }

    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150-18, 20, 100, 100), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 150-18, 20, 100, 100), "" + playerScore02);

        if (GUI.Button(new Rect((Screen.width / 2) - (121 / 2), 35, 121, 53), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;
            theBall.SendMessage("ResetBall");
        }
    }
}
