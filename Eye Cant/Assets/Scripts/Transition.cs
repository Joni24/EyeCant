using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition Instance { get; private set; }

    [SerializeField] private Animation animation = null;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void FadeBlack()
    {
        animation.Play("FadeBlack");
    }

    public void FadeNormal()
    {
        animation.Play("FadeNormal");
    }
}
