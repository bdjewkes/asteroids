using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {


    public int player = 1;
    public string thrust;
    public string yaw;
    public string fire; 
    

    void Awake()
    {
/*        if (player == 1 || player != 2)
        {
            Debug.LogError("You must set the player value to either 1 or 2.  Defaulting to player1");
            player = 1;
        }*/

         switch (player)
        {
            case 1:
                thrust = "P1Power";
                yaw = "P1Yaw";
                fire = "P1Fire";
                break;
            case 2:
                thrust = "P2Power";
                yaw = "P2Yaw";
                fire = "P2Fire";
                break;
             default:
                thrust = "P1Power";
                yaw = "P1Yaw";
                fire = "P1Fire";
                break;
         }
    }

	// Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
