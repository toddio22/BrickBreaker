using System.Collections.Generic;
using UnityEngine;

public class BrickRandomizer : MonoBehaviour
{

    public GameObject[] brickPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Transform> existingBricks = new List<Transform>();
        foreach (Transform row in transform)
        {
            foreach (Transform brick in row)
            {
                existingBricks.Add(brick);
            }
        }
        
        foreach (Transform brick in existingBricks)
        {
            
            Vector3 position = brick.position;
            Quaternion rotation = brick.rotation;
            Transform parent = brick.parent;

            Destroy(brick.gameObject);

            int index = Random.Range(0, brickPrefabs.Length);
            Instantiate(brickPrefabs[index], position, rotation, parent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
