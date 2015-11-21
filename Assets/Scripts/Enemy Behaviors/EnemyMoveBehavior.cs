using UnityEngine;
using System.Collections;

public class EnemyMoveBehavior : AbstractEnemyBehavior
{
    private int tileSize = 4;
    private int step;
    public int stride = 2;
    public int moveChance = 10;

    void FixedUpdate()
    {
        step = tileSize * stride;

        if (Random.Range(-moveChance, moveChance) == 0)         // Flytt opp
        {
            MoveUp();
        }
        else if (Random.Range(-moveChance, moveChance) == 1)    //Flytt ned
        {
            MoveDown();
        }
        else if (Random.Range(-moveChance, moveChance) == 2)    // Flytt høyre
        {
            MoveRight();
        }
        else if (Random.Range(-moveChance, moveChance) == 3)    // Flytt venstre
        {
            MoveLeft();
        }
        else if (Random.Range(-moveChance, moveChance) == 4)    // Gjør ingenting
        {
            Debug.Log("Do nothing");
        }

    }

    void MoveUp()
    {
        transform.Translate(new Vector3(0, step, 0));
    }

    void MoveDown()
    {
        transform.Translate(new Vector3(0, -step, 0));
    }

    void MoveRight()
    {
        transform.Translate(new Vector3(step, 0, 0));
    }

    void MoveLeft()
    {
        transform.Translate(new Vector3(-step, 0, 0));
    }
}
