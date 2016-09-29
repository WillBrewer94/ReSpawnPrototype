using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject player;
    public float maxSpeed = 10f;
    public float jumpForce = 100f;
    bool facingRight = true;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Left and right movement
        float move = Input.GetAxis("PS4_DPadX");
        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight) {
            Flip();
        } else if (move < 0 && facingRight) {
            Flip();
        }
    }

    void Update() {
        //Jump
        if (Input.GetButtonDown("PS4_X")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            Time.timeScale = 0.05f;
        } else {
            Time.timeScale = 1f;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
