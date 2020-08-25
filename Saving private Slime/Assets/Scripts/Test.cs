//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float[] SR;
    public float crocenka;

    private float avarageOfSR = 0;

    private void Start()
    {
        for (int i = 0; i < SR.Length; i++)
        {
            avarageOfSR += SR[i];
        }
        avarageOfSR /= SR.Length;

        float itog = 0.5f * avarageOfSR + 0.2f * crocenka + 0.3f * ((0.5f * avarageOfSR + 0.2f * crocenka) / 0.7f);
        print(itog);
    }
}
