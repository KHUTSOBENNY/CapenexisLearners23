using System.ComponentModel.DataAnnotations;


namespace CapenexisLearners23.Models
{
    public class Learner
    {
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public string Surname { get; set; }
        public string LearnerIdNumber { get; set; }
        public string Course { get; set; }
        public int Price { get; set; }
        
    }
}
