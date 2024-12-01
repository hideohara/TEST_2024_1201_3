using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        //Transform myTransform = this.transform;
        // ローカル座標基準で、現在の回転量へ加算する
        //myTransform.Rotate(1.0f, 0.0f, 0.0f);
        transform.Rotate(1.0f, 0.0f, 0.0f);

    }
}
