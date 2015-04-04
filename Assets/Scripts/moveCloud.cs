using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {
	Transform tT;
	public float speed;
	Vector2 newPosition;
	// Use this for initialization
	void Start () {
		tT = transform;
		calculateNewPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		tT.transform.Translate (Vector2.right * - speed * Time.deltaTime);
		if (tT.transform.position.x <= -6.6) {
			calculateNewPosition ();
			tT.transform.position = newPosition;
		}
	}
	void calculateNewPosition() {
		newPosition = new Vector2 (6.6f, Random.Range (1f, 3f));
		speed = Random.Range (0.5f, 1.0f);
	}
}
