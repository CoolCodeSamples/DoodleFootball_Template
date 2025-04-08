using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static string FormatTimer(int timer)
    {
        int minutes = timer / 60;
        int seconds = timer - minutes * 60;

        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
