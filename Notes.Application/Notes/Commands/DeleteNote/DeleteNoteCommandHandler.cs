using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INotesDbContext _context;
    public DeleteNoteCommandHandler(INotesDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Id);

        _context.Notes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
