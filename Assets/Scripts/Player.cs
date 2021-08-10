using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float move_speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        var new_Xpos = transform.position.x + deltaX;
        var new_Ypos = transform.position.y + deltaY;
        transform.position = new Vector2(new_Xpos,new_Ypos);
    }
}
