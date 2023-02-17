using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI treasureCounter;
    // Update is called once per frame
    void Update()
    {
        if(TreasureCollider.count > 1)
        {
            treasureCounter.text = TreasureCollider.count.ToString() + " treasures are remaining";
        } else if(TreasureCollider.count == 1)
        {
            treasureCounter.text = "Only 1 treasure is left";
        } else
        {
            treasureCounter.text = "No treasures is left";
        }
        
    }
}
