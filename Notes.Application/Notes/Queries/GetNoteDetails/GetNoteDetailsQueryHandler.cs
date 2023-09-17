using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryHandler
    : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    private readonly INotesDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Id);

        return _mapper.Map<NoteDetailsVm>(entity);
    }
}
