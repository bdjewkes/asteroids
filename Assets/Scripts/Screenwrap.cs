using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Screenwrap : MonoBehaviour {
    public bool wrapHorizontal;
    public bool wrapVertical;
    public GameObject wrapTo;

    void Awake()
    {
        if (wrapTo == null)
        {
            Debug.LogError("Missing component I neeeeeeeeed!!!");
        }
    }

    void OnTriggerEnter(Collider theCollision)
    {
        float x = theCollision.transform.position.x;
        float z = theCollision.transform.position.z;
<<<<<<< HEAD
        if (wrapHorizontal) x = wrapTo.transform.position.x;
        if (wrapVertical) z = wrapTo.transform.position.z;
=======
        if (wrapHorizontal)
        { 
            x = wrapTo.transform.position.x;
        }
        if (wrapVertical)
        {
            z = wrapTo.transform.position.z;
        }
>>>>>>> 469d02faf86516c2d114832df017bfc373c71dd2
        theCollision.transform.position = new Vector3(x, theCollision.transform.position.y, z);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wrapTo.transform.position,wrapTo.transform.localScale);
    }
}
