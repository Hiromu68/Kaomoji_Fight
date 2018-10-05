﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTimer : MonoBehaviour {

    float countTime = 0;

	// Use this for initialization
	void Start () {
        SceneManagerController.LoadScene();
	}
	
	// Update is called once per frame
	void Update () {
        countTime += Time.deltaTime;//スタートしてからの秒数を格納

        if(countTime > 3.0f)
        {
            SceneManagerController.ChangeCene();
        }
		
	}
}
