using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed=8;
    private float _rotate = 100f;
    int _isRunning ;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
       // _isRunning = animator.StringToHash("isRunning");
        
    }

    // Update is called once per frame
    void Update()
    {
        // aller vers l'avant
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0f, 0f, _speed * Time.deltaTime);
            Debug.Log("Z is press");

        }
        //aller vers l'arriere
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -_speed * Time.deltaTime);
            Debug.Log("Z is press");

        }

        //tourner a gauche
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -_rotate *Time.deltaTime,0f );
            Debug.Log("Z is press");

        }

        //tourner à doite
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, _rotate * Time.deltaTime, 0f);
            Debug.Log("Z is press");

        }
    }
}
