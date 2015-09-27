using UnityEngine;
using System.Collections;

public static class CustomExtensions {



	public static void TurnGameObjectOnAndOff(this GameObject Object)
    {

        if (Object.activeSelf)
        {
            Object.SetActive(false);
        }
        else
        {
            Object.SetActive(true);
        }
    }

    public static string ConvertBoolToString(this bool value)
    {
        if (value)
        {
            return "Yes";

        }
        else
        {
            return "No";
        }
    }
}
