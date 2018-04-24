using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

	float rotSpeed = 360f;
    [SerializeField] bool spitter;
    float direction;
    float directionX;



	Transform player;
    // Use this for initialization

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {
  
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        if (spitter)
        {
            transform.up = dir;
        }
        else
        {

            if (player == null)
            {
                return;

            }
            

            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
	}
}
