using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCarrotScript : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int health = 1;
    public PlayerHealthScript playerHealthScript;

    private void Start()
    {
        playerHealthScript = GameObject.Find("TestPlayer").GetComponent<PlayerHealthScript>();
    }
    void Update()
    {
        //if de state is true doe dan dit:
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealthScript.playerHealth -= 1;
            //Moet de animatie van carrot kapot gaan afspelen.
            Destroy(gameObject);
        }
    }
}