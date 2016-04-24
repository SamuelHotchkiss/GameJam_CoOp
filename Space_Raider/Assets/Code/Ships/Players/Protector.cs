using UnityEngine;
using System.Collections;

public class Protector : PlayerShip
{

    public GameObject Shield;
    float Energy = 100;
    bool Regin = false;
    bool CanUse = true;
    protected override void Init()
    {
        base.Init();
		Shield.GetComponent<BoxCollider>().enabled = false;
        Shield.GetComponent<Renderer>().enabled = false;
    
    }
   
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

        if (Input.GetAxis(control + "LTrigger") > 0.0f)
        {
            if(Energy >= 0 && !Regin)
            {
                Energy -= 20 * Time.deltaTime;
                Shield.GetComponent<BoxCollider>().enabled = true;
                Shield.GetComponent<Renderer>().enabled = true;
            }
            else
            {
				Shield.GetComponent<BoxCollider>().enabled = false;
                Shield.GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
			Shield.GetComponent<BoxCollider>().enabled = false;
            Shield.GetComponent<Renderer>().enabled = false;
        }

        if (Energy < 0 && !Regin)
        {
            Regin = true;
        }

        if(Regin)
        {
            Energy += 10 * Time.deltaTime;
            if (Energy >= 100)
            {
                Energy = 100;
                Regin = false;
            }
        }
        Debug.Log(Energy);
    }

}
