using MLAPI;
using UnityEngine;

public class SwapWeaponScript : NetworkBehaviour
{
    public GameObject[] weapons;

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            #region Weapon Swap
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
            }
            #endregion
        }

    }
}
