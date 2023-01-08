using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPosition : MonoBehaviour
{
    bool win=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -606f && win==false)
        {
            winner();
            win= true;

        }
    }

    void winner()
    {
        

            Debug.Log("Vous avez survécu à l'apocalipse!!! Bravo! :D ");
            Time.timeScale = 0f;



        
    }


}
