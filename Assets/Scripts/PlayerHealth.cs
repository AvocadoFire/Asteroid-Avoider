
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Crash()
    {
        gameObject.SetActive(false); 
        //don't destroy because want the player to be able to respawn after watching ad
    }
}
