using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int playerGoalNum = 0;

    public void OnTriggerEnter2D( Collider2D other ) {
        other.gameObject.SendMessage("Respawn");
        GameObject.Find("ScoreCanvas").SendMessage("PlayerScored", playerGoalNum);
    }

}
