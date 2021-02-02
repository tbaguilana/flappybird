using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour{
    private void OnTriggerEnter2D (Collider2D other){
  		if(other.GetComponent<BlueBird>()!= null){
  			GameController.instance.DoubleScored();
  			GameObject player = other.gameObject;
  			Destroy(gameObject);
   		}
   }
}
