using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
    }

    public class LegalPerson : Person
    {
        public string TradingName { get; set; }

        public string Cnpj { get; set; }
    }

    public class PhysicalPerson : Person
    {
        public PhysicalPerson()
        {
            DateOfBirth = DateTime.Now;
        }

        public string Surename { get; set; }

        public string Cpf { get; set; }

        public string RG { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
