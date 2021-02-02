using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    // Start is called before the first frame update
	public static GameController instance;
    public GameObject gameOverImage;
    //public GameObject ignoreColumn;
    public Text ScoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public AudioSource source;
    void Awake(){
        if(instance==null){
        	instance = this;
        } else if(instance != this){
        	Destroy(gameObject); //if thers another gameobject active that is not "this"
        }
    }

    // Update is called once per frame
    void Update(){
        if(gameOver && Input.GetMouseButtonDown(0)){
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Scored(){
    	if(gameOver){
    		return;
    	}
    	score++;
    	source.Play();
    	ScoreText.text = score.ToString();
    }

    public void DoubleScored(){
    	if(gameOver){
    		return;
    	}
    	score+=2;
    	source.Play();
    	ScoreText.text = score.ToString();
    }
    public void GameOver(){
    	gameOverImage.SetActive(true);
    	gameOver = true;
    }

}

//singleton pattern restricts the instantiation of a class to one object; to make sure only one gamecontroller is active 