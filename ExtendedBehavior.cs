using System;
using System.Collections;
using UnityEngine;

public static class ExtendedBehavior
{
    public static void Wait(MonoBehaviour i_behavior, float waitTime, Action action)
    {
        i_behavior.StartCoroutine(Callback(waitTime, action));
    }

    static IEnumerator Callback(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
