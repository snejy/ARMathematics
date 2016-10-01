using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using System.Collections.Generic;

public class TextRecoScript : MonoBehaviour, ITextRecoEventHandler {

    public GameObject prefab;
    public void OnInitialized()
    {
     
    }

  public void OnWordDetected(WordResult word)
    {
        if (word.Word.StringValue == "Water" || word.Word.StringValue == "water")
        { 
            GameObject water = Instantiate(prefab);
            water.transform.position = new Vector3(0.5F, 0.5F, 0.5F); 
            water.transform.localScale = new Vector3(50, 50, 50);
            water.transform.parent = GameObject.FindWithTag("Target").transform;
        }
        Debug.Log("Currently tracked word: " + word.Word.StringValue);
    }
     
    public void OnWordLost(Word word)
    {
        Debug.Log("lost tracked word: " + word.StringValue);
    }



    // Use this for initialization
    void Start () {
        var trBehaviour = GetComponent<TextRecoBehaviour>();
        Debug.Log("Start called");
        if (trBehaviour)
        {
            trBehaviour.RegisterTextRecoEventHandler(this);
            Debug.Log("Registered event handler");
        } else
        {
            Debug.Log("Not registered event handler");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
