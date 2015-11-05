using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
    public float delay = 0.2f;
    public GameObject cube;

    void Start () {
        InvokeRepeating("Spawn", delay, 0.5f);
	}

	void Spawn () {
        GameObject objectLeft = (GameObject)Instantiate(cube, new Vector2(Random.Range(-10, -4), 6), Quaternion.identity);
        GameObject objectRight = (GameObject)Instantiate(cube, new Vector2(Random.Range(4, 10), 6), Quaternion.identity);

        objectLeft.transform.parent = transform;
        objectRight.transform.parent = transform;
    }

}
