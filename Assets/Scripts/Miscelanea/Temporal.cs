using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporal : MonoBehaviour
{
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        print("Morion es genial");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camara.SetActive(!camara.activeSelf);
        }
    }
}
