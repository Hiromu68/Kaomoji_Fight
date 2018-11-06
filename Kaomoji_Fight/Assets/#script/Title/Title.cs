﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class Title : MonoBehaviour
{

    [SerializeField]
    GameObject Manager;
    TitleManager TManager_cs;

   [SerializeField]
    private float speed = 1.0f;

    //private
    private Text text;
    private Image image;
    private float time;

    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start()
    {
        SceneManagerController.LoadScene();
        //アタッチしてるオブジェクトを判別
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }

        TManager_cs = Manager.GetComponent<TitleManager>();
    }

    void Update()
    {
        //オブジェクトのAlpha値を更新
        if (thisObjType == ObjType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if (thisObjType == ObjType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }
        
        //スペースキー(デバッグ用)・1PコントローラーのBボタンが押されたらページをめくる
        if (Input.GetKeyDown(KeyCode.Space) || XCI.GetButtonDown(XboxButton.B, XboxController.First))
        {

            TManager_cs.ChangePage(TitleManager.SELECTMODE.PLAYERNAM);
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}