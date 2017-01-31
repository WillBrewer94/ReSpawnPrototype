using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    Player player;
    Animator anim;
    public Controller2D cursor;

    void Start() {
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
	}
	
	void Update() {
        //Vector2 dirInput = new Vector2(Input.GetAxis("PS4_LeftStickX"), Input.GetAxis("PS4_LeftStickY"));
        Vector2 dirInput = new Vector2(1, 0);
        player.SetDirectionalInput(dirInput);
        //anim.SetFloat("Speed", Mathf.Abs(dirInput.x));

        if(Input.GetButtonDown("PS4_X")) {
            player.OnJumpInputDown();
        }

        if(Input.GetButtonUp("PS4_X")) {
            player.OnJumpInputUp();
        }

        if(Input.GetButtonDown("PS4_Circle")) {
            player.velocity.x = (Mathf.Abs(player.velocity.x) + 100) * Mathf.Sign(player.velocity.x);
            Debug.Log(player.velocity.x);
        }

        if(Input.GetButtonDown("PS4_Square")) {

        }

        if(Input.GetButtonDown("PS4_Triangle")) {
            Debug.Log("Triangle");
        }

        if(Input.GetButtonDown("PS4_R1")) {
            BattleController.Shared().SwitchPause();
            Debug.Log("R1");
        }
    }

    //Returns a vector direction of the right joystick
    Vector2 JoyAngle() {
        //X, Y, and angle of right joystick
        float joyX = Input.GetAxis("PS4_LeftStickX");
        float joyY = Input.GetAxis("PS4_LeftStickY");

        //Gets computes angle from origin of right joystick location
        float joyAngle = Mathf.Atan2(joyX, joyY) * 57;

        return new Vector2(joyX, joyY);
    }
}
