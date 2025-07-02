using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer1 : MonoBehaviour
{
    public GameObject prefabParticleWarpIn1; // Assign the prefab you want to instantiate
    public GameObject prefabPlayer1; // Assign the prefab you want to instantiate
    private float elapsedTime = 0f; // Track elapsed time
    public float maxTimeDelay = 0f;
    private static GameObject playerInstance;

    private void Start()
    {
        GameObject newObjectParticle1 = Instantiate(prefabParticleWarpIn1, Vector3.zero, Random.rotation);
    }

    // Update is called once per frame
    void Update()
    {
 
        // CinemachineVirtualCamera - Follow

        // Update elapsed time
        elapsedTime += Time.deltaTime;

        if (playerInstance == null && elapsedTime >= maxTimeDelay) // Check if the player ship already exists
        {
            playerInstance = Instantiate(prefabPlayer1, Vector3.zero, Quaternion.identity); // Instantiate the object
                   
            GameObject cameraObj = GameObject.Find("CineM1"); // Find by name
            if (cameraObj != null)
            {
                CinemachineVirtualCamera cinemachineCam = cameraObj.GetComponent<CinemachineVirtualCamera>();

                if (cinemachineCam != null)
                {
                    cinemachineCam.m_Follow = playerInstance.transform; // Set follow target
                    cinemachineCam.m_LookAt = playerInstance.transform; // Set look-at target
                }
            }
        }
    }
}
