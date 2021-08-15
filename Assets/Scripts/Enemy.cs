using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]float health = 100;
    [SerializeField]float shot_count,min_shoot = .2f, max_shoot = 3f;
    [SerializeField]GameObject laser_pre;
    [SerializeField]float bullet_speed = 7f;
    [SerializeField]GameObject boom_pre;
    [SerializeField]float boom_time = 1f;
    [SerializeField]AudioClip shoot_sound, die_sound;
    [SerializeField][Range(0,1)]float shoot_sound_volume = 0.2f, die_sound_volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        shot_count = Random.Range(min_shoot,max_shoot);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot_Count();
    }
    private void Shoot_Count()
    {
        shot_count -= Time.deltaTime;
        if(shot_count <= 0f)
        {
            Shoot();
            shot_count = Random.Range(min_shoot,max_shoot);
        }
    }
    private void Shoot()
    {
        GameObject laser = Instantiate(laser_pre, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bullet_speed);
        AudioSource.PlayClipAtPoint(shoot_sound, Camera.main.transform.position, shoot_sound_volume);
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
        Destroy(gameObject);
        GameObject boom = Instantiate(boom_pre, transform.position, transform.rotation);
        Destroy(boom, boom_time);
        AudioSource.PlayClipAtPoint(die_sound, Camera.main.transform.position, die_sound_volume);
    }
}