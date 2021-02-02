using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour{
    private GameObject[] columns;
    private GameObject[] pcolumns;//
    public int poolSize = 5;
    public GameObject column;
    public GameObject powerColumn;//
    private Vector2 poolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    public float spwanRate = 4f;
    public float columnMin = -0.9f;
    public float columnMax = 0.5f;
    private float spawnXPosition = 4f;
    private int current = 0;
    private int pcurrent =0;

    void Start(){
        columns = new GameObject[poolSize];
        pcolumns = new GameObject[poolSize];
        for(int i=0;i <poolSize;i++){
        	columns[i] = (GameObject) Instantiate(column, poolPosition, Quaternion.identity); 
        }
        for(int i=0;i <poolSize;i++){
        	pcolumns[i] = (GameObject) Instantiate(powerColumn, poolPosition, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update(){
    	timeSinceLastSpawned += Time.deltaTime;
    	//if more than 4 secs since last spawned and the game is not over
    	if(!GameController.instance.gameOver && timeSinceLastSpawned >= spwanRate){
    		timeSinceLastSpawned=0;
    		float spawnYPosition = Random.Range(columnMin, columnMax);
    		int p = Random.Range(1,100);
    		if(p % 5 == 0){
	    		pcolumns[pcurrent].transform.position=new Vector2(spawnXPosition, spawnYPosition);
	    		pcurrent++;
    		}
    		columns[current].transform.position = new Vector2(spawnXPosition, spawnYPosition);
    		current++;
    		if (current >= poolSize){
    			current = 0;
    		}
    		if (pcurrent >= poolSize){
    			pcurrent = 0;
    		}
    	}
    }
}
