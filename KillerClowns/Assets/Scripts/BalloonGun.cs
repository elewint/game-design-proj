using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGun : MonoBehaviour
{
    public GameObject spawnObject; 
    public GameObject handBalloonAnimal; 
    public Vector3 gunSize;
    private MeshCollider gunRenderer;
    private Color balloonColor;

    // Start is called before the first frame update
    void Start()
    {
        gunSize = GetComponent<Collider>().bounds.size;
        handBalloonAnimal = handBalloonAnimal.transform.GetChild(0).gameObject;

        balloonColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 1f);
        handBalloonAnimal.GetComponent<Renderer>().material.color = balloonColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            // print("space key was pressed");
            // print(transform.position);
            Vector3 newPosition = transform.position + new Vector3(gunSize.x / 2, gunSize.y / 2, 0);
            // print(transform.position);
            // print(gunSize.x);
            GameObject newSpawnObj = Instantiate(spawnObject, newPosition, Random.rotation);
            newSpawnObj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = balloonColor;

            balloonColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            handBalloonAnimal.GetComponent<Renderer>().material.color = balloonColor;

            //newSpawnObj.transform.localScale += new Vector3(10f, 10f, 10f);
            Rigidbody balloon_Rigidbody = newSpawnObj.GetComponent<Rigidbody>();
            balloon_Rigidbody.AddForce(transform.right * 600f);
        }
    }
}
