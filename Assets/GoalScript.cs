using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameClearText;
    public static bool isGameClear = false;
 

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("GOAL");
        gameClearText.SetActive(true);
        isGameClear = true;
    }
}
