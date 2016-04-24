//using UnityEngine;
//using System.Collections;

//public class CameraBehavior : MonoBehaviour {

//    // Use this for initialization
//    private Camera cam;
//    public float ZoomSpeed = 10;
//    public float ZoomCap = 1000;
//    Vector3 OriginalPos;
//    public GameObject Manager;
//    private Plane[] planes;
//    void Start () {
//        cam = Camera.main;
//        OriginalPos = cam.GetComponent<Transform>().position;
//        planes = GeometryUtility.CalculateFrustumPlanes(cam);
//    }


//    bool AabbToPlane(Plane plane, Bounds aabb)
//    {
//        Vector3 CenterPoint = (aabb.max + aabb.min) * 0.5f;
//        float Radius = aabb.extents.x * Mathf.Abs(plane.normal.x) + aabb.extents.y * Mathf.Abs(plane.normal.y) + aabb.extents.z * Mathf.Abs(plane.normal.z);
//        float Distance = plane.GetDistanceToPoint(CenterPoint);
//        if (Distance > Radius)
//        {
//            return plane.GetSide(CenterPoint);
//        }
//        else if (Distance < -Radius)
//        {
//            return plane.GetSide(CenterPoint);
//        }
//        return false;
	    
//    }
  
//    bool CheckBounds(Bounds BoundingVolume)
//    {
//        foreach (Plane _plane in planes)
//        {
//            if (!AabbToPlane(_plane, BoundingVolume))
//                return false;
//        }
//        return true;
//    }
//    // Update is called once per frame
//    void Update () {

//        //Set camera to center of positions of players
//        Vector3 AveragePos = Vector3.zero;
//        foreach (GameObject player in Manager.GetComponent<GameManager>().Players)
//        {
//            AveragePos += player.GetComponent<Transform>().position;
//        }
//        AveragePos = AveragePos / 4;
//        cam.GetComponent<Transform>().position = new Vector3(AveragePos.x, cam.GetComponent<Transform>().position.y,AveragePos.z);
//        Debug.Log(AveragePos);
//        //Create bounding box around players, check camera frustum agaisnt bounding box to see if it is inside
//        Vector3 Max, Min;
//        Max = Min = new Vector3(Manager.GetComponent<GameManager>().Players[0].GetComponent<Transform>().position.x, Manager.GetComponent<GameManager>().Players[0].GetComponent<Transform>().position.y, Manager.GetComponent<GameManager>().Players[0].GetComponent<Transform>().position.z);
//        //z up x left/right
//        for (int i = 1; i < Manager.GetComponent<GameManager>().Players.Length; i++)
//        {
//            if (Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.x > Max.x)
//                Max.x = Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.x;
//            if (Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.z > Max.z)
//                Max.z = Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.z;

//            if (Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.x < Min.x)
//                Min.x = Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.x;
//            if (Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.z < Min.z)
//                Min.z = Manager.GetComponent<GameManager>().Players[i].GetComponent<Transform>().position.x;
//        }
//        Bounds BoundingVolume = new Bounds();
//        BoundingVolume.max = Max;
//        BoundingVolume.min = Min;

//        if(!CheckBounds(BoundingVolume))
//        {
//            cam.GetComponent<Transform>().position = new Vector3(cam.GetComponent<Transform>().position.x, cam.GetComponent<Transform>().position.y + ZoomSpeed * Time.deltaTime, cam.GetComponent<Transform>().position.z);
//        }
//        if (cam.GetComponent<Transform>().position.y > ZoomCap)
//            cam.GetComponent<Transform>().position = new Vector3(cam.GetComponent<Transform>().position.x, ZoomCap, cam.GetComponent<Transform>().position.z);


//    }
//}
