using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damage_dealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damage_dealer);
    }
    private void ProcessHit(DamageDealer damage_dealer)
    {
        health -= damage_dealer.Get_Damage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}