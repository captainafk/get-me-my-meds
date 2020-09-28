using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cologne;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public Vector3[] colognePoints;
    public Vector3[] NPCPoints;

    public int cologneSpawnInterval;
    public int NPCS1pawnInterval;
    public int NPCS2pawnInterval;
    public int NPCS3pawnInterval;
    void Start()
    {
        InvokeRepeating("CologneBirther", 5, cologneSpawnInterval);
        InvokeRepeating("NPC1Birther", 0, NPCS1pawnInterval);
        InvokeRepeating("NPC2Birther", 0, NPCS2pawnInterval);
        InvokeRepeating("NPC3Birther", 0, NPCS3pawnInterval);
    }



    void Update()
    {

    }

    public void CologneBirther()
    {
        int number = Random.Range(0, 5);
        Instantiate(cologne, colognePoints[number], Quaternion.identity);
    }

    public void NPC1Birther()
    {
        int number = Random.Range(0, 5);
        Instantiate(NPC1, NPCPoints[number], Quaternion.identity);
    }
    public void NPC2Birther()
    {
        int number = Random.Range(0, 5);
        Instantiate(NPC2, NPCPoints[number], Quaternion.identity);
    }
    public void NPC3Birther()
    {
        int number = Random.Range(0, 5);
        Instantiate(NPC3, NPCPoints[number], Quaternion.identity);
    }
}
