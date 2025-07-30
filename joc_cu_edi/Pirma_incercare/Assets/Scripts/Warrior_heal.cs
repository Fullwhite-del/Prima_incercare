using UnityEngine;

public class Warrior_heal : MonoBehaviour
{
    public int healing = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Healing_pumpkin>().GetHealth(healing);
    }
}