using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text text;
    float time = 0f;
    bool noWin = true;
    public MyLeaderboard leaderboard;
    public GameObject viwe;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (noWin)
        {
            time += Time.deltaTime;


            text.text = Mathf.FloorToInt(time / 60).ToString() + ":" + (time - Mathf.Floor(time / 60) * 60).ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        noWin = false;
        leaderboard._playerScore = 1000000 - Mathf.RoundToInt(time * 100);
        viwe.SetActive(true);


    }
}
