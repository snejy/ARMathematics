using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddPointLabels : MonoBehaviour {
	public string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H", "K", "L", "M", "N"};

	void Start () {
	    Text text = GetComponent<Text>();
		Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        GameObject g = GameObject.Find("Cube");
        for(int i=0; i<8; i++) {
        	Vector3 vec = vertices[i];
	        TextMesh mh = g.GetComponentInChildren<TextMesh>();
	        TextMesh tm = Instantiate(mh);
	        tm.transform.SetParent(g.transform, true);
			tm.text = letters[i];
			tm.color = Color.black;
			tm.transform.localPosition = new Vector3(vec.x, vec.y, vec.z);
	  		tm.characterSize = 4F;
	  		tm.fontSize = 10;
        }
    }	
	
	// Update is called once per frame
	void Update () {
	
	}

}
