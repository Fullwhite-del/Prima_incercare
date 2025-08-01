using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Warrior_Blue")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);

        }
    }
}