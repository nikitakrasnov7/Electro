using UnityEngine;

public class Toggle : GameeObjects
{

    [SerializeField] private bool isDesctroy; 
    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        if (GetComponent<DerToggle>().isActive)
        {

            GetComponent<DerToggle>().OffingToggle();
            if (isDesctroy)
            {
                Destroy(gameObject);
            }
        }
    }

}
