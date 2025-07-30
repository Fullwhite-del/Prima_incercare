using UnityEngine;

public class Healing_pumpkin : MonoBehaviour
{

    public int Healing;
    public PlayerHealth playerHealth;
    
    public void GetHealth(int quantity)
    {
        //Healing += quantity;

        if (playerHealth.currentHealth == playerHealth.maxHealth)
        {
            Destroy(gameObject);
        }
        playerHealth.ChangeHealth(Healing);
    }
}
