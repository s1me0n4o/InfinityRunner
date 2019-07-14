using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private EnvironmentManager environmentManager;

    private void OnEnable()
    {
        environmentManager = EnvironmentManager.Instance();
        print("TEST");
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return new WaitForSeconds(0.5f);
            environmentManager.ReplacePlatform(this.transform.parent.gameObject);
        }
    }
}
