using Alunos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Alunos.Context
    {
  
        public class EFContext : DbContext
            {

            public EFContext() : base("Projeto") { }

            public DbSet<Aluno> alunos { get; set; }

            }
     }
    