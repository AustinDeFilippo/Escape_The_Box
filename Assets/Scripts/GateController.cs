using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject gate;
    private bool gateHidden = false;

    void Update()
    {
        if (!gateHidden && GameState.Instance != null && GameState.Instance.Score >= 3)
        {
            if (gate != null)
            {
                gate.SetActive(false); 
                gateHidden = true;     
                Debug.Log("Gate has disappeared!");
            }
        }
    }
}

