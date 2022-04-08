using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    public AudioClip songOnHit;

    private void Start()
    {
        GameManager.money += 1;
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = songOnHit;
        audio.Play();
        PlayerPrefs.SetInt("Money", GameManager.money);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
