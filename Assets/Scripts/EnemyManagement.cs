using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour {


    public Rigidbody2D enemy;

    private int randomNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        randomNumber = Random.Range(0, 1000);

        if (randomNumber == 0)
        {
            Instantiate(enemy);
        }

       
	}
}
