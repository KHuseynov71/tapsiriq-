using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class User
    {
        private string _pasword;
        public int Id { get; set; }
        public string Pasword
        {
            get
            {
                return _pasword;
            }
            set
            {
                if (Validation.PaswordIsAllowed(value))
                {
                    _pasword = value;
                }
            }
        }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool Status { get; set; }
    }
}
