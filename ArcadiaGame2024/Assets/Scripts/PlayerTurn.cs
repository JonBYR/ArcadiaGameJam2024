using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResearchArcade;
using Unity.VisualScripting;

public class PlayerTurn : MonoBehaviour
{
    Vector3 origianlPosition;
    public GameObject ball;
    int mana = 10;
    // Start is called before the first frame update
    void Start()
    {
        origianlPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerAttack()
    {
        if (ArcadeInput.Player1.JoyUp.HeldDown)
        {
            ball.SetActive(true);
            StartCoroutine("BallAttack");
        }
    }
    IEnumerator BallAttack()
    {
        int moveCycle = 0;
        int damage = 1;
        bool movedown = false;
        if(movedown == false)
        {
            ball.transform.position = ball.transform.position + new Vector3(0, 0.1f, 0);
            moveCycle++;
            if (moveCycle > 3)
            {
                movedown = true;
                moveCycle = 0;
            }
        }
        else
        {
            ball.transform.position = ball.transform.position - new Vector3(0, -0.1f, 0);
            if(Vector3.Distance(ball.transform.position, origianlPosition) <= 0.5 && Vector3.Distance(ball.transform.position, origianlPosition) > 0)
            {
                if (ArcadeInput.Player1.JoyUp.HeldDown)
                {
                    movedown = false;
                    damage++;
                }
                else if(ArcadeInput.Player1.JoyRight.HeldDown)
                {
                    Damage(damage);
                    yield break;
                }
                else //if player misses input
                {
                    yield break;
                }
            }
            yield break;
        }
        yield return new WaitForSeconds(0.5f);
    }
    void Damage(int dam)
    {

    }
}
