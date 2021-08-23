using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

using NotesMVVM.Model;

namespace NotesMVVM
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection") { }
        public DbSet<Note> Notes { get; set; }
    }
}
