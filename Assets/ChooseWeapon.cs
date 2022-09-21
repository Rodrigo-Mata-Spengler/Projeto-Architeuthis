
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    public int SelectWeapon = 0;
    private void Start()
    {
        SelectedWeapon();
    }
    private void Update()
    {
        int previousSelectedWeapon = SelectWeapon;


        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(SelectWeapon >= transform.childCount - 1)
            {
                SelectWeapon = 0;
            }
            else
            {
                SelectWeapon ++;
            }

        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectWeapon <= 0)
            {
                SelectWeapon = transform.childCount -1;
            }
            else
            {
                SelectWeapon --;
            }

        }

        if(previousSelectedWeapon != SelectWeapon)
        {
            SelectedWeapon();
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == SelectWeapon)
            {
                weapon.gameObject.SetActive(true); 
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
