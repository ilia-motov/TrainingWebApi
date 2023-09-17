using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Common;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNodeCommandHandler : IRequestHandler<UpdateNodeCommand>
{
    private readonly INotesDbContext _context;

    public UpdateNodeCommandHandler(INotesDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateNodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Id);

        entity.Details = request.Details;
        entity.Title = request.Title;
        entity.EditTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
