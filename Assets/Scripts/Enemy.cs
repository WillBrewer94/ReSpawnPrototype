using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public BoxCollider2D collider;
    public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            Debug.Log("Hit");
            sprite.color = Color.red;
        } 
    }

    void OnTriggerExit2D(Collider2D col) {
        sprite.color = Color.black;
    }
}
