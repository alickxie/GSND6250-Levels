using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
   public AudioSource coinCollect;
   public AudioSource Stairsfx;
   bool singlePlay = true;

   // Make GameManager a instance
   public static GameManager instance;

   void Start()
   {
      // Set the instance to this script
      instance = this;
   }

   public void PlayCoinCollect()
   {
      coinCollect.Play();
   }

   public void StairRaising()
   {
      if (singlePlay)
      {
         Stairsfx.Play();
         singlePlay = false;
      }
   }
}
