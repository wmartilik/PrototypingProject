using UnityEngine;

public class SwapWeaponScript : MonoBehaviour
{
    public GameObject[] weapons;

    // Update is called once per frame
    void Update()
    {

        #region Weapon Swap
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(true);
        }
        #endregion
    }
}
