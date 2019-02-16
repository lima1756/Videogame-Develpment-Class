using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dirt;
    private bool[,,] dirtGrid;
    void Start()
    {
        dirtGrid = new bool[4,16,16];
        for(int i = 0; i<16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                Instantiate(dirt,new Vector3(i-8,.5f, j - 8),new Quaternion());
                Instantiate(dirt, new Vector3(i - 8, 1.5f, j - 8), new Quaternion());
                dirtGrid[0, i, j] = true;
                for(int k = 1; k<3; k++)
                {
                    dirtGrid[k, i, j] = dirtGrid[k - 1, i, j] && Random.value > .65f;
                    if(dirtGrid[k, i, j])
                    {
                        Instantiate(dirt, new Vector3(i - 8, k+1.5f, j - 8), new Quaternion());
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
