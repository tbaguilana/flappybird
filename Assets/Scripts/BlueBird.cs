using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : MonoBehaviour{
    // Start is called before the first frame update
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animator;
    private AudioSource source;
    public AudioClip hit;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (!isDead){
        	if(Input.GetMouseButtonDown(0)){
        		rb2d.velocity = Vector2.zero;//everytime the object jumps the velocity is reset to zero so the next thing will always be the same 
                //add force 
                //vector2 has two floating point values which correspond to the x and y axis 
                //x = 0 because the object is not moving horizontally 
                rb2d.AddForce(new Vector2(0, upForce));
                source.Play();
        	}
        }
    }

    //if it hits the column or the ground 
    void OnCollisionEnter2D(){
        source.clip = hit;
        source.Play();
        isDead = true;
        rb2d.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        GameController.instance.GameOver();
    }
}
