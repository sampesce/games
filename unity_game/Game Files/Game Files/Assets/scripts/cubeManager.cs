using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {

	// Use this for initialization

    public GameObject cube;

	void Start () {

        for (int i = 0; i < 4; i++)
        {

            Instantiate(cube,new Vector3(i, 0,0), Quaternion.identity);

        }

	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
