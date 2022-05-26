using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float limit = 30.0f;
    public GameObject text;
    public GameObject player;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
        timeText.text = "Žc‚èŽžŠÔ:" + limit + "•b";
    }

    // Update is called once per frame
    void Update()
    {
        if(restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }

        if(limit < 0)
        {
            restart.PrintGameOver();

            return;
        }

        limit -= Time.deltaTime;
        timeText.text = "Žc‚èŽžŠÔ:" + limit.ToString("f1") + "•b";
    }

   
}
