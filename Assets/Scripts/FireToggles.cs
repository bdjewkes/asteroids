using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
public class FireToggles : MonoBehaviour {
    List<FireAI> fireControls; 
    void Start()
    {
        var fireControls = GetComponentsInChildren<FireAI>().ToList();
    }
    void OnGUI()
    {
        var fireControls = GetComponentsInChildren<FireAI>().ToList();

        fireControls.ForEach(e=>
            e.firewhenready=GUILayout.Toggle(e.firewhenready, "Enable "+e.gameObject.name)
            );

    }
}
