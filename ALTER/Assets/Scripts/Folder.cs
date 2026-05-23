using UnityEngine;

public class Folder : MonoBehaviour
{
    public GameObject folder;
    public GameObject folderIcon;
    public bool isFolderActive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isFolderActive == false)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        folder.SetActive(true);
        folderIcon.SetActive(false);
        isFolderActive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        folder.SetActive(false);
        folderIcon.SetActive(true);
        isFolderActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
