﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class DummySceneStart : MonoBehaviour {

    [SerializeField, Header("プレイ人数（デバッグ用）")]
    private int Player_Num = 2;
    private PlayeData playerdata;

    [SerializeField, Header("選択したステージ名(.txt記述しなくて良い)（デバッグ用）")]
    private string textmame = "stage1";

    [SerializeField, Header("プレイヤーの顔（デバッグ用）")]
    Sprite[] playersface;
   
    private void Awake()
    {
        string DammySelectStage = System.IO.File.ReadAllText("Assets/Resources/Texts/" + textmame + ".txt", Encoding.GetEncoding("Shift_JIS"));

        playerdata = new PlayeData(Player_Num, playersface, DammySelectStage);
    }

    // Use this for initialization
    void Start () {
        SceneManagerController.LoadScene();
		
	}
	
}
