using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    private Vector3 _direction = Vector2.right;
    public float speed = 1f;
    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);//29.52
            float height = 2.0f * (this.rows - 1);
            Vector2 centering= new Vector2(-width/2,-height/2);
            Vector3 rowposition = new Vector3(centering.x, centering.y+(row * 2.0f), 0.0f);
            for (int col = 0; col < this.columns; col++)
            {
                Invader invader =Instantiate(prefabs[row],this.transform);
                Vector3 position = rowposition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;
        Vector3 leftedge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightedge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                  continue;  
            }

            if (_direction==Vector3.right&&invader.position.x>=rightedge.x-1)
            {
                advancerow();
            }
            else if (_direction == Vector3.left && invader.position.x <= leftedge.x+1)//+1 for padding.
            {
                advancerow();//33.40
            }
        }
    }

    private void advancerow()
    {
        _direction.x *= -1f;
        Vector3 position = this.transform.position;
        position.y -= 1f;
        this.transform.position = position;
    }

}

