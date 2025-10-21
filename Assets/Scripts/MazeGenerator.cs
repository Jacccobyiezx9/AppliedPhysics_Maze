using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Walls")]
    public GameObject smallWall;
    public GameObject mediumWall;
    public GameObject largeWall;

    [Header("Ground Size")]
    public Vector3 ground = new Vector3(7, 1, 7);

    [Header("Max Walls")]
    public int smallWallMax = 10;
    public int mediumWallMax = 6;
    public int largeWallMax = 3;

    [Header("Endpoints")]
    public Transform start;
    public Transform finish;

    [Header("LayerMask")]
    public LayerMask endpoint;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnWalls(largeWall, largeWallMax);
        SpawnWalls(mediumWall, mediumWallMax);
        SpawnWalls(smallWall, smallWallMax);
    }

    private void SpawnWalls(GameObject wall, int max)
    {
        for (int i = 0; i < max; i++) 
        {
            Vector3 randomWallPos = new Vector3
                (Random.Range(-ground.x * 3f, ground.x * 3f), 1.5f, 
                    Random.Range(-ground.z * 3f, ground.z * 3f));

            Quaternion randomWallRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            if (Physics.Raycast(randomWallPos + Vector3.up * 10f , Vector3.down, out RaycastHit hit, 20f, endpoint))
            {
                if (hit.collider.CompareTag("Start") && hit.collider.CompareTag("Finish"))
                {
                    i--;
                    continue;
                }
            }

            Collider[] hitColliders = Physics.OverlapBox(randomWallPos, new Vector3(2f, 2f, 2f), Quaternion.identity, endpoint);
            if(hitColliders.Length > 0)
            {
                i--;
                continue;
            }

            Instantiate(wall, randomWallPos, randomWallRot);
        }

    }
}
