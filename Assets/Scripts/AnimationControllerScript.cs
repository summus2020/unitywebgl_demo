using UnityEngine;


public class AnimationControllerScript : MonoBehaviour
{
    public GameObject panel_info;
    private bool panelIsOpen = false;


    public void openInfoPanel()
    {

        if (!panelIsOpen)
        {
            if(panel_info != null)
            {
                panel_info.GetComponent<Animator>().SetTrigger("open");
                panelIsOpen = true;
            }
        }
        else
        {
            if (panel_info != null)
            {
                panel_info.GetComponent<Animator>().SetTrigger("close");
                panelIsOpen = false;
            }
        }
    }

    
}
