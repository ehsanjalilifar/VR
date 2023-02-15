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
        treasureCounter.text = TreasureCollider.count.ToString() + " is remaining";
    }
}
