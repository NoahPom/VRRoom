using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAlien : MonoBehaviour
{
    public AnimationClip animationClip;
    public float delay = 1.0f;

    private float timer = 0f;
    private bool isPlaying = false;

    void Start()
    {
        PlayAnimation();
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0f;
                PlayAnimation();
            }
        }
    }

    void PlayAnimation()
    {
        if (animationClip != null)
        {
            GetComponent<Animation>().clip = animationClip;
            GetComponent<Animation>().Play();
            isPlaying = true;
        }
    }
}
