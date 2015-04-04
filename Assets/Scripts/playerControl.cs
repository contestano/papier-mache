using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
	Transform tT;
	bool isJumping;
	float xDirection, jumpForce, jump;
	public float speed;
	public GameObject player;
	// Use this for initialization
	void Start () {
		tT = transform;
		speed = 3.0f;
		isJumping = false;
		jumpForce = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		xDirection = Input.GetAxis ("Horizontal");
		Debug.Log (isJumping);
		tT.transform.Translate (Mathf.Abs (xDirection) * speed * Time.deltaTime, 0f, 0f);
		if (xDirection > 0) {
			transform.eulerAngles = new Vector2 (0, 0);
		}
		if (xDirection < 0){
			transform.eulerAngles = new Vector2 (0, 180);
		}
		jump = Input.GetAxis ("Jump");
		if (jump != 0 && !isJumping) {
			Rigidbody2D playerPhysics = (Rigidbody2D)player.GetComponent<Rigidbody2D>();
			playerPhysics.AddForce(new Vector2(xDirection, jumpForce), ForceMode2D.Impulse);
			isJumping = true;
		}
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isJumping = false;
		}
	}
}