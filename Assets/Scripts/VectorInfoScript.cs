using System.Collections.Generic;
using UnityEngine;

public class VectorInfoScript : MonoBehaviour
{
    public Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>()
    {
        //{"Back Panel", new Vector3(46, -1.550397f, -76.9f)},
        {"Back Panel", new Vector3(-46.0f, -1.6f, 76.9f)},
        {"battery", new Vector3(19.5f, -26.4f, -60.9f)},
        {"Cable", new Vector3(41.4f, -3.6f, -27.1f)},
        {"Engine", new Vector3(-1.9f, -14.4f, 15.1f)},
        {"Filter", new Vector3(-96.9f, -4.7f, -11.1f)},
        {"Front.Panel", new Vector3(-19.9f, -2.1f, -98.2f)},
        {"Oil Tank", new Vector3(-26.8f, 1.4f, -49.6f)},
        {"Pipe.1", new Vector3(-5.9f, -7.0f, 0.0f)},
        {"Pipe.2", new Vector3(22.1f, -11.0f, -26.8f)},
        {"Radiator", new Vector3(90.0f, -15.8f, -16.9f)},
        {"Rama", new Vector3(-39.1f, -3.6f, 160.4f)},
        {"Top Container", new Vector3(-0.3f, 64.1f, 0.0f)}
    };
    public Dictionary<string, Vector3> startPositions = new Dictionary<string, Vector3>();
    public Dictionary<string, Quaternion> startRotations = new Dictionary<string, Quaternion>();

    private void Start()
    {

        GameObject generator = GameObject.Find("Generator");

        foreach(Transform child in generator.transform)
        {
            this.startPositions.Add(child.name, child.transform.position);
            this.startRotations.Add(child.name, child.transform.rotation);
            
        }
    }
}
