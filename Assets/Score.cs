using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text sc;

    public ArabaHareket arabaHareket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sc.text = arabaHareket.puan.ToString();
    }
}
