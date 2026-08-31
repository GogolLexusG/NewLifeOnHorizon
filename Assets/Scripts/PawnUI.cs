using System.Collections.Generic;
using UnityEngine;

public class PawnUI : MonoBehaviour
{
    public PawnScript thisPawn;
    public List<RectTransform> bar = new List<RectTransform>();

    //private void Update()
    //{
    //    float[] procents = new float[8];
    //    procents[0] = thisPawn.hunger;
    //    procents[1] = thisPawn.thirst;

    //    procents[3] = thisPawn.starvation / 800f * 100f;
    //    procents[4] = thisPawn.dehydration / 800f * 100f;

    //    procents[5] = thisPawn.sanity / 450f * 100f;
    //    procents[6] = thisPawn.fear / 1600f * 100f;
    //    procents[7] = thisPawn.mood / 2050f * 100f;

    //    for (int thisBar = 0; thisBar < bar.Count; thisBar++)
    //    {
    //        bar[thisBar].sizeDelta = new Vector2(procents[thisBar] * 2, 50);
    //        bar[thisBar].localPosition = new Vector2(-100 + procents[thisBar], 0);
    //    }
    //}
}
