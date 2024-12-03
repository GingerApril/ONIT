using System.ComponentModel.DataAnnotations;

namespace Laba1Marta.Models
{
    public class TableModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int Number { get; set; }
    }

}