using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadWallController : MonoBehaviour
{
    public float speed = 0.05f;
    public float max_x = 10.0f;

    public GameObject player;
    public GameObject text;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(speed, 0, 0);

        if(this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1;
        }

        if(restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == player.name)
        {
            restart.PrintGameOver() ;

            return;
        }
    }

    
}
