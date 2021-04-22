using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferData 
{
    private static TransferData Instance;
    public int clicks = 1;
    public static TransferData _instance
    {
        get
        {
            if(Instance==null)
            {
                Instance = new TransferData();
            }
            return Instance;
        }
    }
    private TransferData() {}
    public float speed = 2.5f;
    public float spawnTime = 0.8f;
    public int layer = 0;
}
