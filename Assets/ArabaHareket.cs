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
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunBitti == false)
        {
            GetComponent<Rigidbody>().AddForce(UnityEngine.Vector3.left * 20, ForceMode.Force);
        }
        else if (oyunBitti == true)
        {
            GetComponent<Rigidbody>().AddForce(UnityEngine.Vector3.zero);
        }

        if (GetComponent<Rigidbody>().position.x <= 90)
        {
            GetComponent<Rigidbody>().velocity = UnityEngine.Vector3.zero;
            Invoke("restart", 3f);
            oyunBitti = true;
        }
        if (Input.GetKey("d") && oyunBitti == false)
        {
            GetComponent<Rigidbody>().AddForce(0,0,10);
        }

        if (Input.GetKey("a") && oyunBitti == false)
        {
            GetComponent<Rigidbody>().AddForce(0,0,-10);
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
