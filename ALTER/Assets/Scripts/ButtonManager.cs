using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject victims;
    public GameObject suspects;
    public GameObject leads;

    public void Victims()
    {
        victims.SetActive(true);
        suspects.SetActive(false);
        leads.SetActive(false);
    }

    public void Suspects()
    {
        victims.SetActive(false);
        suspects.SetActive(true);
        leads.SetActive(false);
    }

    public void Leads()
    {
        victims.SetActive(false);
        suspects.SetActive(false);
        leads.SetActive(true);
    }
}
