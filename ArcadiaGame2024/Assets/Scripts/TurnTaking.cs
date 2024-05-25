using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResearchArcade; //SDK for arcade machine inputs
public enum Turns
{
    PLAYER,
    ENEMY
}
public class TurnTaking : MonoBehaviour
{
    Turns turn;
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        turn = Turns.PLAYER; //start with player turn
        CallTurn();
    }

    // Update is called once per frame
    void CallTurn()
    {
        switch(turn)
        {
            case Turns.PLAYER:
                player.GetComponent<PlayerTurn>().PlayerAttack();
                Debug.Log("Player Called"); //function should repeatedly call itself once a player/enemy turn ends
                turn = Turns.ENEMY;
                break;
            case Turns.ENEMY:
                Debug.Log("Enemy Called");
                turn = Turns.PLAYER;
                break;
        }
    }
}
