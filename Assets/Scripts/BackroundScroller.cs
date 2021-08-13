using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundScroller : MonoBehaviour
{
    [SerializeField]float scroll_speed = 0.5f;
    Material back_material;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        back_material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scroll_speed);
    }

    // Update is called once per frame
    void Update()
    {
        back_material.mainTextureOffset += offset * Time.deltaTime;
    }
}
