using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour
{
    public bool isCatched = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(!isCatched && coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // geeft de boolean terug true or false gevangen
            isCatched = coll.gameObject.GetComponent<Character1controller>().setHasObject(this.gameObject);
        }
        else if(coll.gameObject.tag == "ground")
        {
            if (isCatched == true)
            {
            
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

}