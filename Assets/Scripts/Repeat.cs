using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour{
	private BoxCollider2D ground;
	private float groundxlength; //x axis length of image

    void Start(){
        ground = GetComponent<BoxCollider2D>();
        groundxlength = ground.size.x;

    }

    // Update is called once per frame
    void Update(){
        //check if time to reposition
        //calculate a number from zero (since camera is looking at zero )
        if(transform.position.x < -groundxlength){
        	RepositionBackground(); 
        } 
    }

    private void RepositionBackground(){
    	Vector2 offset = new Vector2(groundxlength  * 2f, 0); // double the length of the ground and pass the object to the new position in front
    	transform.position = (Vector2) transform.position + offset;
    }
}
