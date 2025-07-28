using UnityEngine;

public class Elevation_Exit1 : MonoBehaviour
{

    public Collider2D[] mountainColliders1;
    public Collider2D[] boundaryCollisions1;
    //public bool firstlayer = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warrior_Blue")//&& firstlayer)
        {
            foreach (Collider2D mountain in mountainColliders1)
            {
                mountain.enabled = false;
            }

            foreach (Collider2D boundary in boundaryCollisions1)
            {
                boundary.enabled = true; 
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
            //firstlayer = false;
        }
        //else if(collision.gameObject.tag == "Warrior_Blue" && firstlayer == false)
        //{
        //    foreach (Collider2D mountain in mountainColliders)
        //    {
        //        mountain.enabled = true;
        //    }

        //    foreach (Collider2D boundary in boundaryCollisions)
        //    {
        //        boundary.enabled = false;
        //    }

        //    collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        //    firstlayer = true;
        //}



    }


}
