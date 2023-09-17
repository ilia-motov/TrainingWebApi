using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfiguration;

namespace Notes.Persistence;

public class NoteDbContext : DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }
    public NoteDbContext(DbContextOptions<NoteDbContext> dbContextOptions)
        : base(dbContextOptions) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
