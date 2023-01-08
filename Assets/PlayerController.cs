using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed=5;
    private float _rotate = 100f;
    int _isRunning ;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        // aller vers l'avant
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0f, 0f, _speed * Time.deltaTime);
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);

        }
        //aller vers l'arriere
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -_speed * Time.deltaTime);
            animator.SetBool("isBackward", true);


        }
        else
        {
            animator.SetBool("isBackward", false);

        }

        //tourner a gauche
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -_rotate *Time.deltaTime,0f );
            

        }

        //tourner à doite
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, _rotate * Time.deltaTime, 0f);
            animator.SetBool("isTurn", true);

        }
        else
        {
            animator.SetBool("isTurn", false);
        }
    }
}
