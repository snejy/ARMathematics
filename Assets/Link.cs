using UnityEngine;
using System.Collections;

public class Link : MonoBehaviour {

    public GameObject other;

	// Use this for initialization
	void Start () {
        GameObject link = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        link.transform.parent = this.transform.parent.transform;
        link.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        link.transform.localPosition = new Vector3((this.transform.localPosition.x - other.transform.localPosition.x)/2, 
            (this.transform.localPosition.y - other.transform.localPosition.y)/2,(this.transform.localPosition.z - other.transform.localPosition.z)/2);
        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
