using System.Net.NetworkInformation;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "NAND"
        Read file;
        Chip[] chips = new Chip[];
        using (StreamReader reader = new StreamReader("../Chips/" + gameObject.name + ".json"))
        {
            string json = reader.ReadToEnd();
            file = JsonSerializer.Deserialize<Read>(json);
        }
        foreach (var (index, gate) in file.gates) {
            gate.id = index;
            if(gate.type == "AND") {
                chips[index] = new And();
                chips[index].input1 = gate.from[0];
                chips[index].input2 = gate.from[1];
            } else if(gate.type == "NOT") {
                chips[index] = new Not();
                chips[index].input = gate.from[0];
            } else if(gate.type == "INPUT") {
                chips[index] = new Input();
            } else if(gate.type == "OUTPUT") {
                chips[index] = new Output();
                chips[index].input = gate.from[0];
            }
            if(chips[index]) {
                chips[index].id = gate.id;
                chips[index].type = gate.type; 
                chips[index].chips = chips; 
            }
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
        public int id { get; set;};
        public string type { get; set; };
        public int[] from { get; set; } = [];
        public Chip[] chips { get; set; } = null;
    }

    private class Add : Chip {
        public int input1 { get; set;};
        public int input2 { get; set;};
        public int output { get; set;};
        public void updateOutput() {
            output = chips[input1].output == 1 && chips[input2].output == ? 1 : 0;
        }
    }

    private class Not : Chip {
        public int input { get; set;};
        public int output { get; set;};
        public void updateOutput() {
            output = abs(chips[input].output - 1);
        }
    }

    private class Input : Chip {
        public int output { get; set;};
    }

    private class Output : Chip {
        public int input { get; set;};
    }
}
