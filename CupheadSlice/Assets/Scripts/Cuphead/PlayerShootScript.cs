using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform firePoint;//Naar rechts.
    public Transform firePoint2;//Naar boven.
    public Transform firePoint3;//Naar links.
    public Transform firePoint4;//Naar links schuin naar boven.
    public Transform firePoint5;//Naar rechts schuin naar boven.

    public GameObject blueBulletPrefab;
    public GameObject blueBulletPrefab1;

    private Transform activeFirePoint;

    public float blueBulletForce = 50f;

    private float shootTimer;
    public float reloadTimer;

    private string lastDirection;

    private void Start()
    {
        shootTimer = reloadTimer;

        //GameObject bullet = Instantiate(blueBulletPrefab) as GameObject;
        //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void Update()
    {
        //Debug.Log(new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);
        if (Input.GetKey(KeyCode.X))
        {
            shootTimer += Time.deltaTime; // Start de timer.
            if (shootTimer > reloadTimer)
            {
                Vector2 firePointPosition = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * 2, transform.position.y + Input.GetAxis("Vertical") * 2);
                firePoint.position = firePointPosition;
                Vector2 shootDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * blueBulletForce;
                if (Input.GetAxis("Vertical") >= 0 && Mathf.Abs(shootDirection.magnitude) > 0)
                {
                    Shoot(shootDirection);
                }
                //if (Input.GetKey(KeyCode.LeftArrow))
                //{
                //    Shoot1(new Vector2(100,0));
                //}
                shootTimer = 0.0f;
            }
        }
    }

    void Shoot(Vector2 direction)//Maakt de bullet aan en schiet maar rechts.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }
    void Shoot1(Vector2 direction)//Maakt de bullet aan en schiet maar rechts.
    {
        GameObject blueBullet1 = Instantiate(blueBulletPrefab1, firePoint.position, firePoint.rotation);//Andere prefab?
        Rigidbody2D rb = blueBullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }
}