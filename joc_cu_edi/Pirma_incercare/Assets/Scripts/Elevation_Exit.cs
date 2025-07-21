using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{

    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryCollisions;
    //public bool firstlayer = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warrior_Blue")//&& firstlayer)
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }

            foreach (Collider2D boundary in boundaryCollisions)
            {
                boundary.enabled = false;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
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
