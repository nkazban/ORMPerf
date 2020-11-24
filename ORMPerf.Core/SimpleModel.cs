using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMPerf
{
    public class SimpleModel
    {
        static Random _r = new Random();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string About { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }

        public static SimpleModel CreateRandom()
        {
            var model = new SimpleModel();
            model.Name = $"{_r.Next(int.MinValue, int.MaxValue)}";
            model.Birth = DateTime.Now;
            model.About = "";
            return model;
        }
    }
}