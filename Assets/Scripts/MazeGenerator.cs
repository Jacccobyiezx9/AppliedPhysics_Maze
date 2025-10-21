using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Walls")]
    public GameObject smallWall;
    public GameObject mediumWall;
    public GameObject largeWall;

    [Header("Ground Size")]
    public Vector3 ground = new Vector3(7, 1, 7);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnWalls()
    {

    }

}
