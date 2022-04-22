using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneControllerScript : MonoBehaviour
{

    public Camera cam;
    public Transform generator;
    public bool grouped = true;
    public List<GameObject> parts = new List<GameObject>();
    private VectorInfoScript vectorInfo;
    public string selectedItem = "Generator";
    public Text text_hint;
    public Text text_title;
    private ItemDescriptionScript descriptor;

    public static string sendObjectName = "";

    // Start is called before the first frame update
    void Start()
    {
        if(vectorInfo == null)
        {
            vectorInfo = GetComponent<VectorInfoScript>();
        }
        cam.transform.LookAt(generator);
        descriptor = GetComponent<ItemDescriptionScript>();
        descriptor.setTextForItem("Generator");
        selectedItem = "Generator";
    }

    private void Update()
    {

        //cam.transform.LookAt(generator);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            groupGenerator();
        }
    }

    public void groupGenerator()
    {
        if (grouped)
        {
            foreach (GameObject child in parts)
            {
                Vector3 targetVector = vectorInfo.positions[child.transform.name];
                child.GetComponent<ObjectManagerScript>().moveToPosition(targetVector);
            }
            text_hint.GetComponent<Animator>().SetTrigger("show_hint");
            GameObject.Find("Button Group").GetComponentInChildren<Text>().text = "Group";
        }
        else
        {
            foreach (GameObject child in parts)
            {
                if (vectorInfo.startPositions.ContainsKey(child.name))
                {
                    Vector3 targetPosition = vectorInfo.startPositions[child.transform.name];
                    Quaternion targetRotation = vectorInfo.startRotations[child.transform.name];
                    child.GetComponent<ObjectManagerScript>().moveToStartPosition(targetPosition, targetRotation);

                }
                else
                {
                    print("Key " + child.name + " not found  in dictionary");
                }
            }
            text_hint.GetComponent<Animator>().SetTrigger("hide_hint");
            GameObject.Find("Button Group").GetComponentInChildren<Text>().text = "Ungroup";
            text_title.text = "Portable Generator";
            descriptor.setTextForItem("Generator");
            selectedItem = "Generator";
        }
    }

    public void onObjectSelected(string selectedName)
    {
        selectedItem = selectedName;
        descriptor.setTextForItem(selectedName);
    }

    //############################################
    public void startDetailScene()
    {
        SceneControllerScript.sendObjectName = selectedItem;
        GameObject obj1 = GameObject.Find(selectedItem);

        if(selectedItem != "Generator")
        {
            obj1.transform.SetParent(null);
        }
        DontDestroyOnLoad(obj1);
        SceneManager.LoadScene("DetailScene", LoadSceneMode.Single);
    }
}
