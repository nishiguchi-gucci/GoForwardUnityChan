using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    Animator animator;//アニメーションするためのコンポーネント入れる

    Rigidbody2D rigid2D;//移動させるコンポーネントを入れる

    private float groundLevel = -3.0f; //地面の位置

    private float dump = -0.8f;//ジャンプ速度の減衰

    float jumpVelocity = 20;//ジャンプの速度

    private float deadLine = -9;//ゲームオーバーになる位置

	// Use this for initialization
	void Start () {
        //アニメータのコンポーネント取得
        this.animator = GetComponent<Animator>();

        //Rigidbody2Dのコンポーネント取得
        this.rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメータを調整
        this.animator.SetFloat("Horizontal", 1);

        //着地してるかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときにボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //上向きに力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向に速度を減衰する
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if(transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GamrOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unityちゃんを破棄
            Destroy(gameObject);
        }
	}
}
