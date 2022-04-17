using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowCoralSpawner : MonoBehaviour
{
    public bool coralSpawned;

    [SerializeField]
    Rigidbody2D rainbowCoral;

    [SerializeField]
    Vector3 boatSpawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!coralSpawned)
        {
            SpawnCoral();
        }
    }

    void SpawnCoral()
    {
        boatSpawner = GameObject.Find("Boat").transform.position;
        boatSpawner.y -= 2;

        Rigidbody2D clone;
        clone = Instantiate(rainbowCoral, boatSpawner, transform.rotation);

        coralSpawned = true;
    }
}
