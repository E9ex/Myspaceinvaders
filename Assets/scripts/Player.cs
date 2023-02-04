using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserprefab;
    public float speed = 5f;

    public bool _laseractive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
       else if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))//zero is left click
        {
            shoot();
        }
    }

    private void shoot()
    {
        if (!_laseractive)
        {
            
            Projectile projectile = Instantiate(laserprefab, transform.position, quaternion.identity);//norotation
            projectile.Destroyed += Laserdestroyed;
            _laseractive = true;
        }
        
    }

    private void Laserdestroyed()
    {
        _laseractive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("invader")|| other.gameObject.layer==LayerMask.NameToLayer("missile"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

       
    }
}
