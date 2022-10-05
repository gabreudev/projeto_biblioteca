using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Context
{
    public class ListaContext : DbContext
    {
        public ListaContext(DbContextOptions<ListaContext> options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos{get; set; }
    }
}