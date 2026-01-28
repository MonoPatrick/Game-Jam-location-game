using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public List<CardSystem> playerCards;
    public List<CardSystem> enemyCards;
    private CardSystem playerCard;
    private CardSystem enemyCard;
    bool battleInitiated;
    public bool playersTurn;
    public bool enemysTurn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleInitiated = true;
        playerCard = playerCards[0];
        enemyCard = enemyCards[0];
    }

    // Update is called once per frame
    void Update()
    {
        //player being damaged
        if (battleInitiated && enemysTurn)
        {
            if (playerCard.cardHealth > 0)
            {
                // normal damage
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // neutral attacks 1.0x
                    if ((int)playerCard.cardType == (int)enemyCard.cardType)
                    {
                        playerCard.loseHealth(enemyCard.cardDamage);
                    }
                    // super effective 1.5x
                    if ((int)enemyCard.cardType == 2 && (int)playerCard.cardType == 1 || (int)enemyCard.cardType == 1 && (int)playerCard.cardType == 0 || (int)enemyCard.cardType == 0 && (int)playerCard.cardType == 2)
                    {
                        playerCard.loseHealth(enemyCard.cardDamage * 1.5f);
                    }
                    // not effective 0.5x
                    if ((int)enemyCard.cardType == 1 && (int)playerCard.cardType == 2 || (int)enemyCard.cardType == 0 && (int)playerCard.cardType == 1 || (int)enemyCard.cardType == 2 && (int)playerCard.cardType == 0)
                    {
                        playerCard.loseHealth(enemyCard.cardDamage * 0.5f);
                    }
                }
                // if defense is less then attack subtract the defense from the attack and do the damage
                if (Input.GetKeyDown(KeyCode.K))
                {
                    if ((int)playerCard.cardType == (int)enemyCard.cardType)
                    {
                        if (playerCard.cardDefense < enemyCard.cardDamage)
                        {
                            playerCard.loseHealth(enemyCard.cardDamage - playerCard.cardDefense);
                        }
                    }
                    // super effective 1.5x
                    if ((int)enemyCard.cardType == 2 && (int)playerCard.cardType == 1 || (int)enemyCard.cardType == 1 && (int)playerCard.cardType == 0 || (int)enemyCard.cardType == 0 && (int)playerCard.cardType == 2)
                    {
                        if (playerCard.cardDefense < enemyCard.cardDamage * 1.5f)
                        {
                            playerCard.loseHealth(enemyCard.cardDamage - playerCard.cardDefense);
                        }
                    }
                    // not effective 0.5x
                    if ((int)enemyCard.cardType == 1 && (int)playerCard.cardType == 2 || (int)enemyCard.cardType == 0 && (int)playerCard.cardType == 1 || (int)enemyCard.cardType == 2 && (int)playerCard.cardType == 0)
                    {
                        if (playerCard.cardDefense < enemyCard.cardDamage * 0.5f)
                        {
                            playerCard.loseHealth(enemyCard.cardDamage - playerCard.cardDefense);
                        }
                    }

                   
                }
            }
        }
        //enemy being damaged
        if (battleInitiated && playersTurn)
        {
            if (playerCard.cardHealth > 0)
            {
                // normal damage
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // neutral attacks 1.0x
                    if ((int)playerCard.cardType == (int)enemyCard.cardType)
                    {
                        enemyCard.loseHealth(enemyCard.cardDamage);
                    }
                    // super effective 1.5x
                    if ((int)playerCard.cardType == 2 && (int)enemyCard.cardType == 1 || (int)playerCard.cardType == 1 && (int)enemyCard.cardType == 0 || (int)playerCard.cardType == 0 && (int)enemyCard.cardType == 2)
                    {
                        enemyCard.loseHealth(enemyCard.cardDamage * 1.5f);
                    }
                    // not effective 0.5x
                    if ((int)playerCard.cardType == 1 && (int)enemyCard.cardType == 2 || (int)playerCard.cardType == 0 && (int)enemyCard.cardType == 1 || (int)playerCard.cardType == 2 && (int)enemyCard.cardType == 0)
                    {
                        enemyCard.loseHealth(enemyCard.cardDamage * 0.5f);
                    }
                }
                // if defense is less then attack subtract the defense from the attack and do the damage
                if (Input.GetKeyDown(KeyCode.K))
                {
                    if ((int)playerCard.cardType == (int)enemyCard.cardType)
                    {
                        if (enemyCard.cardDefense < playerCard.cardDamage)
                        {
                            enemyCard.loseHealth(playerCard.cardDamage - enemyCard.cardDefense);
                        }
                    }
                    // super effective 1.5x
                    if ((int)playerCard.cardType == 2 && (int)enemyCard.cardType == 1 || (int)playerCard.cardType == 1 && (int)enemyCard.cardType == 0 || (int)playerCard.cardType == 0 && (int)enemyCard.cardType == 2)
                    {
                        if (enemyCard.cardDefense < playerCard.cardDamage * 1.5f)
                        {
                            enemyCard.loseHealth(playerCard.cardDamage - enemyCard.cardDefense);
                        }
                    }
                    // not effective 0.5x
                    if ((int)playerCard.cardType == 1 && (int)enemyCard.cardType == 2 || (int)playerCard.cardType == 0 && (int)enemyCard.cardType == 1 || (int)playerCard.cardType == 2 && (int)enemyCard.cardType == 0)
                    {
                        if (enemyCard.cardDefense < playerCard.cardDamage * 0.5f)
                        {
                            enemyCard.loseHealth(playerCard.cardDamage - enemyCard.cardDefense);
                        }
                    }
                }
            }
        }
        if (enemyCard.cardHealth == 0.0f)
        {
            Debug.Log("enemy dead");
            enemyCard.gameObject.SetActive(false);
        }

    }
}
