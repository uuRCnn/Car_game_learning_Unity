using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = System.Numerics.Vector3;

public class ArabaHareket : MonoBehaviour
{
    private bool oyunBitti = false;
    public int puan = 0;
    private bool aTuşunaBasıldı = false;
    private bool dTuşunaBasıldı = false;
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && oyunBitti == false)
        {
            dTuşunaBasıldı = true;
        }

        if (Input.GetKey("a") && oyunBitti == false)
        {
            aTuşunaBasıldı = true;
        }
    }

    private void FixedUpdate()
    {
        var compenent_rb = GetComponent<Rigidbody>();
        if (oyunBitti == false)
        {
            compenent_rb.velocity = new UnityEngine.Vector3(-20, 0, compenent_rb.velocity.z);
            // compenent_rb.AddForce(UnityEngine.Vector3.left * 160, ForceMode.Force);
        }
        else if (oyunBitti == true)
        {
            compenent_rb.AddForce(UnityEngine.Vector3.zero);
        }
        
        if (dTuşunaBasıldı)
        {
            compenent_rb.AddForce(0,0,120);
            dTuşunaBasıldı = false;
        }
        if (aTuşunaBasıldı)
        {
            compenent_rb.AddForce(0,0,-120);
            aTuşunaBasıldı = false;
        }
        if (compenent_rb.position.x <= 65)
        {
            compenent_rb.velocity = UnityEngine.Vector3.zero;
            Invoke("restart", 3f);
            oyunBitti = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Invoke("restart", 3f);
            oyunBitti = true;
        }

        if (collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunBitti = false;
    }
}
