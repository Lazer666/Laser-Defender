using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration parameters
    [Header("Player Movement")]
    [SerializeField]float move_speed = 10f;
    [SerializeField]float pad = 0.5f;
    [SerializeField]int health = 200;
    [SerializeField]AudioClip shoot_sound,die_sound;
    [SerializeField][Range(0,1)]float shoot_sound_volume = 0.2f, die_sound_volume = 0.5f;

    [Header("Bullet")]
    [SerializeField]GameObject laser_pre;
    [SerializeField]float bullet_speed = 10f,bullet_period = 0.1f;
    bool shooting = false;
    Coroutine coshoot;

    float xmin,xmax,ymin,ymax;
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
        Shoot();
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        var new_Xpos = Mathf.Clamp((transform.position.x + deltaX), xmin+pad, xmax-pad);
        var new_Ypos = Mathf.Clamp((transform.position.y + deltaY), ymin+pad, ymax-pad);
        transform.position = new Vector2(new_Xpos,new_Ypos);
    }
    private void Shoot()
    {
        if(Input.GetButton("Fire1") && !shooting)
        {
            coshoot = StartCoroutine(CoShoot());
        }
    }
    IEnumerator CoShoot()
    {
        shooting = true;

        GameObject laser = Instantiate(laser_pre, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,bullet_speed);
        AudioSource.PlayClipAtPoint(shoot_sound, Camera.main.transform.position, shoot_sound_volume);
        yield return new WaitForSeconds(bullet_period);

        shooting = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damage_dealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damage_dealer)
        {
            return ;
        }
        ProcessHit(damage_dealer);
    }
    private void ProcessHit(DamageDealer damage_dealer)
    {
        health -= damage_dealer.Get_Damage();
        damage_dealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        FindObjectOfType<Level>().Load_Game_Over();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(die_sound, Camera.main.transform.position, die_sound_volume);
    }
}