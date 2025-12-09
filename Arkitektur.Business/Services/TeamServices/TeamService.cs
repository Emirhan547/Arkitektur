using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TeamServices
{
    public class TeamService(IGenericRepository<Team>_repository,IUnitOfWork _unitOfWork,IValidator<Team>_validator):ITeamService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamDto createTeamDto)
        {
            var team = createTeamDto.Adapt<Team>();
            var validationResult = await _validator.ValidateAsync(team);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(team);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return BaseResult<object>.Fail("Team Not Found");
            }
            _repository.Delete(team);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            var mappedResult = categories.Adapt<List<ResultTeamDto>>();
            return BaseResult<List<ResultTeamDto>>.Success(mappedResult);
        }



        public async Task<BaseResult<ResultTeamDto>> GetByIdAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return BaseResult<ResultTeamDto>.Fail("Team Not Found");
            }
            var resultTeam = team.Adapt<ResultTeamDto>();
            return BaseResult<ResultTeamDto>.Success(resultTeam);
        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetTeamWithSocialsAsync()
        {
            var query =  _repository.GetQueryable();
            var values=await query.Include(t=>t.TeamSocials).ToListAsync();
            var mappedValues = values.Adapt <List<ResultTeamDto>>();
            return BaseResult<List<ResultTeamDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamDto updateTeamDto)
        {
            var team = updateTeamDto.Adapt<Team>();
            var validationResult = await _validator.ValidateAsync(team);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(team);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
