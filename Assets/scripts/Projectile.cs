using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public Vector3 direction;
   public float speed;
   public System.Action Destroyed;// delegate pattern (to inform.)

   private void Update()
   {
      transform.position+=direction * speed * Time.deltaTime;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (Destroyed!=null)
      {
         this.Destroyed.Invoke();

      }
      Destroy(this.gameObject);
   }
}
