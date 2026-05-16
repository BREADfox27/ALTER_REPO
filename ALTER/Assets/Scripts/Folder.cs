using UnityEngine;

public class Folder : MonoBehaviour
{
    public GameObject folder;
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
        isFolderActive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        folder.SetActive(false);
        isFolderActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
