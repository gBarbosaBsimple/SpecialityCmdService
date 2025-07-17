using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TechnologyRepositoryEF : ITechnologyRepositoryEF
{
    private readonly IMapper _mapper;
    private readonly AbsanteeContext _context;

    public TechnologyRepositoryEF(IMapper mapper, AbsanteeContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> IsRepeated(Guid id)
    {
        var exists = await _context.Technologies.AnyAsync(d => d.Id == id);
        return exists;
    }

    public async Task<ITechnology> AddTechnologyAsync(ITechnology technology)
    {
        var techDM = _mapper.Map<TechnologyDataModel>(technology);

        await _context.Technologies.AddAsync(techDM);
        await _context.SaveChangesAsync();

        var TechAdded = _mapper.Map<ITechnology>(techDM);
        return TechAdded;
    }
}