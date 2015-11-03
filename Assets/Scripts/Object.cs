using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour
{
    public bool isCatched = false;

    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isCatched = true;
            transform.parent = coll.transform;
            transform.position = coll.transform.GetComponentInChildren<playerHands>().transform.position;
            Destroy(GetComponent<Rigidbody2D>());
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