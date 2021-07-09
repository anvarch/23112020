using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image filledPart;

    public void ShowHealthFraction (float fraction)
    {
        //Scale the filledPart to the fraction
        filledPart.rectTransform.localScale = new Vector3(fraction, 1, 1);
        //if (fraction <= 0) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
