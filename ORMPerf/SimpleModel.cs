using System;
using System.ComponentModel.DataAnnotations;

namespace ORMPerf
{
    public class SimpleModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string About { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}