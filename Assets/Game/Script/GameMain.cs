﻿using System.Collections.Generic;
using UnityEngine;
public class GameMain : MonoBehaviour {
    public List<CharacterCCData> CharacterCC_Data;
    public List<questionbankData> questionbank_data;
    // Use this for initialization
    void Start () {
        DataPool.f_InitPool();
        /*CharacterCC_Data = DataPool.m_CharacterDT.dataList;
        //印出JOHN CENA的初始角色等級
        print( CharacterCC_Data.Find( name => name.NAME == "JOHN CENA" ).LV );
        //印出後來增加的人物的STR
        print( CharacterCC_Data.Find( name => name.NAME == "我是後來新增的傢伙" ).STR );

        for ( int i = 0 ; i < CharacterCC_Data.Count ; i++ )
        {
            print( "Int Have Bug 不只不能用int,而且不能有空白 : " + CharacterCC_Data[ i ].Int_have_bug );
        }*/

        questionbank_data = DataPool.m_questiondt.dataList;
        print(questionbank_data.FindAll(name => name.Ch == 1));

    }

    // Update is called once per frame
    void Update () {
	
	}
}
