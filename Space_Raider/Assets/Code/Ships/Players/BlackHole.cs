using UnityEngine;
using System.Collections;

public class BlackHole : PlayerShip
{

    Camera MainCam;
    protected override void Init()
    {
        base.Init();
        MainCam = Camera.main;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


        if (Input.GetAxis(control + "LTrigger") > 0.0f)
        {
            GameObject b = (GameObject)Instantiate(bullet, aimReticule.transform.position, Quaternion.identity);
            b.GetComponent<explodey>().damage = damage;
            b.GetComponent<explodey>().direction = aimReticule.transform.position - transform.position;
            MainCam.GetComponent<BlackHoleRenderer>().BH = b;
        }
        

       
    }

}
