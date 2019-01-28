using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UserShema
    {
        private string name,  mobile,  description,  applicant_SessionId,email;
        private int loantype, buspurpose;
        private decimal amount;



        public string Name { get => name; set => name = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string Description { get => description; set => description = value; }
        public int Loantype { get => loantype; set => loantype = value; }
        public decimal Amount { get => amount; set => amount = value; }

        public int Buspurpose { get => buspurpose; set => buspurpose = value; }
        public string Applicant_SessionId { get => applicant_SessionId; set => applicant_SessionId = value; }

        public string Email { get => email; set => email = value; }
    }
}
