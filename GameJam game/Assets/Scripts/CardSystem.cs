using Unity.VisualScripting;
using UnityEngine;


public enum Type
{
    Blue ,
    Green ,
    Brown 



}


public class CardSystem : MonoBehaviour
{
    public string cardName;
    

    public Sprite cardImage;
    //card type stats
    public Type cardType;
    // attack stats
    //HeaderAttribute cardAttribute;

    public float cardHealth;
    public float cardDamage;
    public float cardDefense;
    
    public void Start()
    {

    }
    public void Update()
    {
        
    }
    public void cardLoss()
    {
        if (cardHealth <= 0.0f)
        {
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }


    public void loseHealth(float x)
    {
        
        cardHealth = cardHealth - x;
        if (cardHealth > 0.0f)
        {
            Debug.Log(cardHealth);
        }
        else
        {
            cardHealth = 0.0f;
            Debug.Log(cardHealth);
            cardLoss();
        }
    }

}
