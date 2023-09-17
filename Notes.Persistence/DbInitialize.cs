namespace Notes.Persistence;

public class DbInitialize
{
    public static void Initialize(NoteDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
