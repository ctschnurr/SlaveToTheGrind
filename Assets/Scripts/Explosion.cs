using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float expandSpeed = 7f;
    float fadeSpeed = .5f;

    Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        expandSpeed = expandSpeed * Time.deltaTime;
        fadeSpeed = fadeSpeed * Time.deltaTime;

        scaleChange = new Vector3(expandSpeed, expandSpeed, expandSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Color tempcolor = GetComponent<SpriteRenderer>().material.color;
        tempcolor.a = Mathf.MoveTowards(tempcolor.a, 0f, fadeSpeed);
        GetComponent<Renderer>().material.color = tempcolor;

        if (transform.localScale.x < 10) transform.localScale += scaleChange;
        if (transform.localScale.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
