using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    //キャッシュ
    PlayerController playerCtrl;

    //基本機能の実装
    private void Awake()
    {
        playerCtrl = GetComponent<PlayerController>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //操作可能か
        if (!playerCtrl.activeSts) return;

        //バット処理
        float joyMv = Input.GetAxis("Horizontal");
        playerCtrl.ActionMove(joyMv);

        //ジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            playerCtrl.ActionJump();
        }

        //攻撃
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
        {
            playerCtrl.ActionAttack();
        }

    }
}
/*
 * プログラムは簡単。AwakeメッセージでPlayerControllerコンポーネントを取得して、そのインスタンスをクラス内でいつでも参照できるようにします。
 * これはUnityプログラムの有名なTIPSの一つで、キャッシュと呼ばれている。
 * Unitynoゲームオブジェクトの検索やコンポーネントの取得、検索動作はあまり高速でないため、このようにシーン起動時に一回だけ呼ばれるAwakwメッセージで処理しておけば、
 * 以後検索などの処理が不要になるため、高速化できる。
 * また、死亡時に操作できるのを防ぐため、activeStsを用いている。
 */
