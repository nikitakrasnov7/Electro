using UnityEngine;

public class TESTOpenLock : MonoBehaviour
{
   [SerializeField] private OpenLock[] OpenLocks;
    private int i =0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < OpenLocks.Length)
            {
                OpenLocks[i].Open();
                i++;
            }
        }
    }
}
