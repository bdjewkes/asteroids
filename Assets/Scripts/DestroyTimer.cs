using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
    public float length = 3; 

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, length);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
