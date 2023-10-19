using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public AudioSource coinCollect;

   public void PlayCoinCollect()
   {
      coinCollect.Play();
   }
}
