using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionScript : MonoBehaviour
{
    public Text text_header;
    public Text text_description;

    private Dictionary<string, string> items = new Dictionary<string, string>() {
        {"Generator", "4000-Watt Open Frame Inverter Generator is one of the most innovative products on the market. Our advanced technology and innovative design will improve the way you power your life." },
        {"Back Panel", "This open frame inverter is 50% quieter and 20% lighter than a traditional 3500-watt portable generator. We cut the noise level in half by integrating Quiet Technology digital inverter components. Then, we created an efficient mechanical design to decrease the overall footprint and weight by 20 percent." },
        {"battery", "With a 0.6-quart oil capacity (recommended 10W-30) and a low oil shut-off sensor, this inverter operates at 64 dBA from 23 feet, which is a bit louder than normal speech"},
        {"Cable", "All the outlets have covers for protection and include a 120V 30A (TT-30R) RV outlet as well as a 120/240V 30A locking outlet (L14-30R) and two 120V 20A household outlets (5-20R)."},
        {"Engine", "Our recoil start features Cold Start Technology, plus the reliable 224cc engine produces 4000 starting watts and 3500 running watts, and runs for 17 hours at 25% load when the 2.9-gallon fuel tank is full."},
        {"Filter", "Buy this fully assembled CARB compliant and EPA certified inverter with confidence – Champion Support and our nationwide network of service centers will back up your purchase with a 3-year limited warranty and FREE lifetime technical support."},
        {"Front.Panel", "Our Quick Touch Panel offers fast access to controls, while Economy Mode monitors power consumption in real time to reduce electrical load. As the electrical load is reduced, the engine idles lower, providing quieter operation, extended engine life and higher fuel economy."},
        {"Oil Tank", "With a 0.6-quart oil capacity (recommended 10W-30) and a low oil shut-off sensor, this inverter operates at 64 dBA from 23 feet, which is a bit louder than normal speech."},
        {"Pipe.1", "Confidently connect your sensitive electronics since our hybrid produces only Clean Power (less than 3% THD)."},
        {"Pipe.2", "Our Quick Touch Panel offers fast access to controls, while Economy Mode monitors power consumption in real time to reduce electrical load. As the electrical load is reduced, the engine idles lower, providing quieter operation, extended engine life and higher fuel economy." },
        {"Radiator", "The optional Parallel Kit, with included standard 50-amp RV outlet, provides a clip-on connection which allows you to increase output by connecting up to two 2800-watt or higher inverters or or open frame inverters."},
        {"Rama", "50% quieter and 20% lighter than a traditional Champion 3500-watt generator, plus our Economy Mode feature saves fuel and extends engine life"},
        {"Top Container", "The optional Parallel Kit, with included standard 50-amp RV outlet, provides a clip-on connection which allows you to increase output by connecting up to two 2800-watt or higher inverters or or open frame inverters."}
    };

    private Dictionary<string, string> names = new Dictionary<string, string>()
    {
        {"Generator", "Portable Generator"},
        {"Back Panel", "Back Panel"},
        {"battery", "Accumulator"},
        {"Cable", "Electric cable"},
        {"Engine", "Engine"},
        {"Filter", "Filter"},
        {"Front.Panel", "Front Panel"},
        {"Oil Tank", "Engine Oil Tank"},
        {"Pipe.1", "Soft Pipe"},
        {"Pipe.2", "Hard Pipe"},
        {"Radiator", "Radiator"},
        {"Rama", "Carcass"},
        {"Top Container", "Fuel Tank"}
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTextForItem(string itemName)
    {
        print("Setting new description");
        if (names.ContainsKey(itemName))
        {
            var clickedItemName = names[itemName];
            var description = items[itemName];
            text_header.text = clickedItemName;
            text_description.text = description;
            //print("Setting new text for " + itemName);
        }
        else
        {
            print("no such key: " + itemName);
        }
    }
}
