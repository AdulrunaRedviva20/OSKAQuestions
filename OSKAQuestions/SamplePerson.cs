using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OSKAQuestions
{
    public class SamplePerson
    {


        private string _name;

        public string Name
        {    
            set {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            
            get => _name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
