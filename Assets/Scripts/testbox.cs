using UnityEngine;

public class testbox : MonoBehaviour
{
public FullScreenShaderController fssc;
    public void OnTriggerEnter(Collider other)
    {
        fssc.StartFreeze();
    }
}
