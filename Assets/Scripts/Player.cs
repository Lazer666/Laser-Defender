using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float move_speed = 10f;
    [SerializeField]float xmin,xmax,ymin,ymax;
    [SerializeField]float pad = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Move_limit();
    }
    private void Move_limit()
    {
        Camera game_camera = Camera.main;
        xmin = game_camera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        xmax = game_camera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        ymin = game_camera.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        ymax = game_camera.ViewportToWorldPoint(new Vector3(0,1,0)).y;
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
        var new_Xpos = Mathf.Clamp((transform.position.x + deltaX), xmin+pad, xmax-pad);
        var new_Ypos = Mathf.Clamp((transform.position.y + deltaY), ymin+pad, ymax-pad);
        transform.position = new Vector2(new_Xpos,new_Ypos);
    }
}
