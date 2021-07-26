using System;
using UnityEngine;


//TODO Разделить лвл и аудио менеджер

public class AudioLevelManager : MonoBehaviour
{
     public Sound[] sounds;
     public static AudioLevelManager instance;
     private int coinsCount = 0;
     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
          }
          else
          {
               Destroy(gameObject);
               return;
          }
          DontDestroyOnLoad(this);
          
          Player.Triggered += PlayerOnTriggered;
          
          foreach (var sound in sounds)
          {
               sound.source = gameObject.AddComponent<AudioSource>();
               sound.source.clip = sound.clip;

               sound.source.volume = sound.volume;
               sound.source.pitch = sound.pitch;
          }
     }

     private void PlayerOnTriggered(Collider obj)
     {
          if (obj.gameObject.CompareTag("Coin"))
          {
               coinsCount++;
          }

          if (coinsCount == 5)
          {
               SceneLoader.LoadSecondScene();
               coinsCount = 0;
          }
     }

     public void Play(string name)
     {
          Sound s = Array.Find(sounds, sound => sound.name == name);
          s.source.Play();
     }
}
