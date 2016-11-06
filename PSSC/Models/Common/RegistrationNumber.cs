using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class RegistrationNumber
    {
        private string _number;
        public string Number { get { return _number; } }

        public RegistrationNumber(string number)
        {
            _number = number;
        }
    }
}
