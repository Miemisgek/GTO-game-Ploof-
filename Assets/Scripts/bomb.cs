using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

    Collider2D[] hitObjects;
    public float bomRadius = 4f;
    public LayerMask whatIsTower;
    public float bomPower = 50f;

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.layer == LayerMask.NameToLayer("tower"))
        {
            hitObjects = Physics2D.OverlapCircleAll(this.transform.position, bomRadius, whatIsTower);

            foreach (Collider2D towerpiece in hitObjects)
            {
                towerpiece.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(bomPower, bomPower), this.transform.position, ForceMode2D.Force);
            }

            Destroy(this.gameObject);
        }

    }
}
