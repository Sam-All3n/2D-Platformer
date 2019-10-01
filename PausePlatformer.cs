using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlatformer : MonoBehaviour {


    public GameObject Menu;
    bool Paused = false;
    float cursorDelay;
    bool haveKilledCursor;
    Info inf;

    void Start()
    {
        Menu.gameObject.SetActive(false);

    }

    void Update()
    {

        if (!haveKilledCursor)
        {
            if (cursorDelay < 0.1f)
            {
                cursorDelay += Time.deltaTime;

            }
            else
            {
                haveKilledCursor = true;
                Cursor.visible = false;
            }
        }


        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                
                Cursor.visible = false;
                Menu.gameObject.SetActive(false);
                Paused = false;
                //GetComponent<Info>().MenuPause();
                Time.timeScale = 1;
             
            }
            else
            {
                Cursor.visible = true;
                Menu.gameObject.SetActive(true);
                Paused = true;
                Time.timeScale = 0;
            }
        }


    }

    public void removeCursior()
    {
        Cursor.visible = false;
    }
}
