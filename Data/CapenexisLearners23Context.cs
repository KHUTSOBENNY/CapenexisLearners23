using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners23.Models;

namespace CapenexisLearners23.Data
{
    public class CapenexisLearners23Context : DbContext
    {
        public CapenexisLearners23Context (DbContextOptions<CapenexisLearners23Context> options)
            : base(options)
        {
        }

        public DbSet<CapenexisLearners23.Models.Learner> Learner { get; set; } = default!;

        public DbSet<CapenexisLearners23.Models.Facilitator> Facilitator { get; set; } = default!;

        public DbSet<CapenexisLearners23.Models.Course> Course { get; set; } = default!;
    }
}
