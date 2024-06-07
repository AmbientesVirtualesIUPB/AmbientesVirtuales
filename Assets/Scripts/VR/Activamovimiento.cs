using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Activamovimiento : MonoBehaviour
{
    public InputActionProperty palanca;
    public Vector2 vPalanca;
    public GameObject rayo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vPalanca = palanca.action.ReadValue<Vector2>();
        if (vPalanca.y > 0.3f && !rayo.activeSelf)
        {
            rayo.SetActive(true);
        }else if (vPalanca.y < 0.3f && rayo.activeSelf)
        {
            rayo.SetActive(false);
        }
    }
}
