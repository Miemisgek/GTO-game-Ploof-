using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {


    public GameObject bomb;
    public Transform bomboverseer;
    public float delay = 1f;
    public float speedBomb = 200f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("shootBomb", 0.5f, delay);
    }
	
	public void shootBomb()
    {
        GameObject bom = (GameObject)Instantiate(bomb, this.transform.position, this.transform.rotation); //je spawnt een bom als gameobject
        bom.transform.parent = bomboverseer;
        bom.GetComponent<Rigidbody2D>().AddForce(transform.right * speedBomb);
    }
}
