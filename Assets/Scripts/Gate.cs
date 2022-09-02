using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        using (StreamReader reader = new StreamReader("../Chips/" + gameObject.name + ".json"))
        {
            string json = reader.ReadToEnd();
        }
        // define inputs
        // load the logic
        // define the outputs
    }

    // Update is called once per frame
    void Update()
    {
        // read inputs
        // send outputs
    }

    private class Read {
        public string name;
        public Dictionary<int, Chip> gates;
    }

    private class Chip {
        public int id;
        public string name;
        public int[] from = [];
    }

    private class Add : Chip {
        public int input1;
        public int input2;
        public int output;

    }

    private class Not : Chip {
        public int input;
        public int output;
    }

    private class Input : Chip {
        public int output;
    }

    private class Output : Chip {
        public int input;
    }
}
