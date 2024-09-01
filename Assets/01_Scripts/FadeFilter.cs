using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FadeFilter : MonoBehaviour
{
    private enum FadeState
    {
        FADEIN,     // 나타남
        FADEOUT,    // 흐려짐
        NON         // 작동 안함
    }

    // 페이드 필터에 붙여서 사용
    [SerializeField] private Image filter;
    private FadeState fadeState;
    private float colorChangeSpeed;

    private void Awake()
    {
        fadeState = FadeState.NON;
        colorChangeSpeed = 0.09f;
    }

    private void Update()
    {
        if (fadeState == FadeState.NON) return;

        switch (fadeState)
        {
            case FadeState.FADEIN:
                if (filter.color.a <= 0.0f)
                {
                    fadeState = FadeState.NON;
                    break;
                }

                filter.color = new Color(filter.color.r, filter.color.g,
                                            filter.color.b, filter.color.a - colorChangeSpeed * Time.deltaTime);
                Debug.Log(filter.color.a);
                break;

            case FadeState.FADEOUT:
                if (filter.color.a >= 255.0f)
                {
                    fadeState = FadeState.NON;
                    break;
                }

                filter.color = new Color(filter.color.r, filter.color.g,
                                            filter.color.b, filter.color.a + colorChangeSpeed * Time.deltaTime);

                break;
        }
    }

    // 밝아지는 거 
    public void fadeIn()
    {
        fadeState = FadeState.FADEIN;
    }

    // 어두워지는 거 
    public void fadeOut()
    {
        fadeState = FadeState.FADEOUT;
    }
}