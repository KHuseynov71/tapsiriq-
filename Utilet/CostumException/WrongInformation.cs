using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilet.CostumException
{
   public  class WrongInformation :Exception
    {
        public WrongInformation(string message) : base(message)
        {

        }
    }
}
