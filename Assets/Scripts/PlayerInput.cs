using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

   
    public int player = 0; // Determines who controls GameObject.  0: computer controlled, 1: player 1, 2: player 2
    public string thrust;
    public string yaw;
    public string fire; 
    

    void Awake()
    {
         switch (player)
        {
            case 0:
                thrust = "Blank";
                yaw = "Blank";
                fire = "Blank";
                break;

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
                thrust = "Blank";
                yaw = "Blank";
                fire = "Blank";
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
