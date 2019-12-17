using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRooms : MonoBehaviour
{

    public GameObject[] rooms;
    public GameObject[] roomLocs;
    public GameObject[] placedRooms;
    //private GameObject[] roomsPicked;
    // Start is called before the first frame update
    void Start()
    {
        rooms = ShuffleArray(rooms);
        Place();
    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject[] ShuffleArray(GameObject[] arraySort)
    {
        int n = arraySort.Length;
        GameObject holder;
        // Sorts arrays given to it        
        while ( n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            holder = arraySort[k];
            arraySort[k] = arraySort[n];
            arraySort[n] = holder;

        }

        return (arraySort);
    }

    void Place()
    {
        placedRooms = new GameObject[roomLocs.Length];
        Vector3 reset = new Vector3(0, 0, 0);

       for (int i = 0; i < roomLocs.Length; i++)
        {
            //placedRooms[i] = Instantiate(rooms[i], roomLocs[i].position, roomLocs[i].rotation);
            placedRooms[i] = Instantiate(rooms[i], reset, Quaternion.identity);
            placedRooms[i].transform.SetParent(roomLocs[i].transform, false);

        }

    }
}
