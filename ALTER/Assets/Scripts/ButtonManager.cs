using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject victims;
    public GameObject suspects;
    public GameObject leads;

    public GameObject miaProfile;
    public GameObject chloeProfile;
    public GameObject walterProfile;

    public GameObject jeffProfile;
    public GameObject roseProfile;
    public GameObject bryanProfile;
    public GameObject carloProfile;
    public GameObject gertrudeProfile;

    public GameObject collarProfile;
    public GameObject woolProfile;
    public GameObject pillsProfile;

    public void Return()
    {
        miaProfile.SetActive(false);
        chloeProfile.SetActive(false);
        walterProfile.SetActive(false);
        jeffProfile.SetActive(false);
        roseProfile.SetActive(false);
        bryanProfile.SetActive(false);
        carloProfile.SetActive(false);
        gertrudeProfile.SetActive(false);
        collarProfile.SetActive(false);
        woolProfile.SetActive(false);
        pillsProfile.SetActive(false);
    }

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

    public void Mia()
    {
        miaProfile.SetActive(true);
    }

    public void Chloe()
    {
        chloeProfile.SetActive(true);
    }

    public void Walter()
    {
        walterProfile.SetActive(true);
    }

    public void Jeff()
    {
        jeffProfile.SetActive(true);
    }

    public void Rose()
    {
        roseProfile.SetActive(true);
    }

    public void Bryan()
    {
        bryanProfile.SetActive(true);
    }

    public void Carlo()
    {
        carloProfile.SetActive(true);
    }

    public void Gertrude()
    {
        gertrudeProfile.SetActive(true);
    }

    public void Collar()
    {
        collarProfile.SetActive(true);
    }

    public void Wool()
    {
        woolProfile.SetActive(true);
    }

    public void Pills()
    {
        pillsProfile.SetActive(true);
    }

    public void GoodEnding()
    {
        SceneManager.LoadScene("GoodEndMenu");
    }

    public void BadEnding()
    {
        SceneManager.LoadScene("BadEndMenu");
    }
}
