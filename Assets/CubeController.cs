using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    private float speed = -12;//キューブの移動速度

    private float deadLine = -10;//消滅の位置

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Unity2D")
        {
            
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
