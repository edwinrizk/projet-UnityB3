using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{
    bool _dead = false;
    public float time = 0f;
    
    public int seconds;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dead == true)
        {
            if (Time.time > time + 5)
            {
                time = Time.time;
                Time.timeScale = 0f;

            }      
            
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "vehicule")
        {
            Debug.Log("DEAD!!!!");
            animator.SetBool("isDown", true);
            _dead= true;

        }
        if (collision.gameObject.tag == "meteor")
        {
            Debug.Log("DEAD!!!!");
            animator.SetBool("isDown", true);
            _dead = true;

        }













    }
}
