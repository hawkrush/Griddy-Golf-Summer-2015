using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public float zMargin = 1f; // Distance in the x axis the player can move before the camera follows.
        //public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
        public float zSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
        //public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
        public Vector3 maxXAndY; // The maximum x and y coordinates the camera can have.
        public Vector3 minXAndY; // The minimum x and y coordinates the camera can have.

        private Transform m_Player; // Reference to the player's transform.


        private void Awake()
        {
            // Setting up the reference.
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private bool CheckZMargin()
        {
            // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
            return Mathf.Abs(transform.position.z - m_Player.position.z) > zMargin;
        }

		/*
        private bool CheckYMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }*/


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
            float targetZ = transform.position.z;
            //float targetY = transform.position.y;

            // If the player has moved beyond the x margin...
            if (CheckZMargin())
            {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
                targetZ = Mathf.Lerp(transform.position.z, m_Player.position.z, zSmooth*Time.deltaTime);
            }

            // If the player has moved beyond the y margin...
            /*if (CheckYMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }*/

            // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
            targetZ = Mathf.Clamp(targetZ, minXAndY.z, maxXAndY.z);
            //targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3(transform.position.x, transform.position.y, targetZ);
        }
    }
}
