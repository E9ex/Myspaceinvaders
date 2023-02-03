using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
   public Sprite[] animationsprites;
   public float animationtime = 1.0f;
   
   private SpriteRenderer _spriteRenderer;
   private int _animationframe;

   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }//liked.

   private void Start()
   {
      InvokeRepeating(nameof(animatesprite),this.animationtime,this.animationtime);
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
}

