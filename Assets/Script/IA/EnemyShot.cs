using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject enemyBullet;

    public Transform spawnBulletPoint;

    private Transform playerPosition;

    public float bulletValeocity = 100;
    
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;

        
        
    }

    
    void Update()
    {
       
    }

    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position = transform.position;
        GameObject newBullet;

        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection, ForceMode.Force);

        Invoke("ShootPlayer",3);
    }
}
