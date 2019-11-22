//based on Ryan Hipple's Unite Demo project
using UnityEngine;
using UnityEngine.UI;

    public class TextReplacer : MonoBehaviour
    {
        public Text Text;
        public StringContainer Variable;
        public bool AlwaysUpdate;
        
        void OnEnable()
        {
            Text.text = Variable.stringVariable;
        }

        void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = Variable.stringVariable;
            }
        }
    }
