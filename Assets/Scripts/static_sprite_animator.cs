using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class static_sprite_animator : MonoBehaviour
{
    public Sprite noise1, noise2, noise3, noise4, noise5, noise6, currentNoise;
    public int randomNumber;
    public Image noise_Image;


    void Update()
    {
        pickRandomNoiseImage();
        noise_Image.sprite = currentNoise;

    }

    void pickRandomNoiseImage()
    {
        randomNumber = Random.Range(1, 6);
        if(randomNumber == 1)
        {
            currentNoise = noise1;
        }
        if(randomNumber == 2)
        {
            currentNoise = noise2;
        }
        if(randomNumber == 3)
        {
            currentNoise = noise3;
        }
        if(randomNumber == 4)
        {
            currentNoise = noise4;
        }
        if(randomNumber == 5)
        {
            currentNoise = noise5;
        }
        if(randomNumber == 6)
        {
            currentNoise = noise6;
        }
    }

}
