using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
   public Sprite[] animationsprites;
   public float animationtime = 1.0f;
   public System.Action killed;
   
   private SpriteRenderer _spriteRenderer;
   private int _animationframe;

   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }//liked.

   private void Start()
   {
      InvokeRepeating(nameof(animatesprite),animationtime,animationtime);
   }

   private void animatesprite()
   {
      _animationframe++;
      if (_animationframe >=animationsprites.Length)
      {
         _animationframe = 0;
         
      }

      _spriteRenderer.sprite = animationsprites[_animationframe];
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.layer==LayerMask.NameToLayer("laser"))
      {
         killed.Invoke();
         gameObject.SetActive(false);
      }
   }
}

