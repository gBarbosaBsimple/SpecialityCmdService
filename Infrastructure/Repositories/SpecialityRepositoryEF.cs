using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SpecialityRepositoryEF : ISpecialityRepositoryEF
{
    private readonly IMapper _mapper;
    private readonly AbsanteeContext _context;

    public SpecialityRepositoryEF(IMapper mapper, AbsanteeContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ISpeciality> AddSpecialityAsync(ISpeciality speciality)
    {
        var specialityDM = _mapper.Map<SpecialityDataModel>(speciality);

        await _context.Set<SpecialityDataModel>().AddAsync(specialityDM);
        await _context.SaveChangesAsync();

        var specialityAdded = _mapper.Map<ISpeciality>(specialityDM);
        return specialityAdded;
    }

    public async Task<ISpeciality?> GetSpecialityByIdAsync(Guid id)
    {
        var specialityDM = await _context.Set<SpecialityDataModel>().AsTracking().FirstOrDefaultAsync(a => a.Id == id);

        if (specialityDM == null) return null;

        var speciality = _mapper.Map<ISpeciality>(specialityDM);
        return speciality;
    }

    public async Task<ISpeciality?> UpdateSpecialityAsync(ISpeciality speciality)
    {
        var existing = await _context.Specialities.FindAsync(speciality.Id);
        if (existing == null)
            return null;

        existing.Description = speciality.Description;
        existing.TechnologyId = speciality.TechnologyId;
        existing.CollaboratorId = speciality.CollaboratorId;
        existing.PeriodDate = speciality.PeriodDate;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao gravar alterações: {ex.Message}");
            throw;
        }

        return new Speciality(
            existing.Id,
            existing.Description,
            existing.TechnologyId,
            existing.CollaboratorId,
            existing.PeriodDate
        );
    }


}