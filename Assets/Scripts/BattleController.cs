using UnityEngine;
using System.Collections;

//Controller for battle scenes
public class BattleController : MonoBehaviour {
    //Singleton battle manager
    private static BattleController shared;

    //Delta time values for gameobjects
    public float playerDeltaTarget = 0;
    public float playerDelta = 0;
    public float enemyDelta;
    public float pauseSmoothTime = 0.5f;

    //Is Time Paused
    private bool isPause;

    void Awake() {
        //Make sure only one battle manager exists at a time
        if(shared == null) {
            shared = this;
        } else {
            Destroy(this.gameObject);
        }
        //Time.timeScale = 0.05f;
    }

    void Update() {
        if(isPause) {
            Mathf.SmoothDamp(playerDelta, playerDeltaTarget, ref playerDelta, pauseSmoothTime);
        } else {
            playerDelta = Time.deltaTime;
        }
    }

    public static BattleController Shared() {
        return shared;
    }

    public bool IsPaused() {
        return isPause;
    }

    public void SwitchPause() {
        isPause = !isPause;
    }
}
