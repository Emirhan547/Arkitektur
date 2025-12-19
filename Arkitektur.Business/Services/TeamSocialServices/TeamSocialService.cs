using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.Repositories.TeamSocialRepositories;
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

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public class TeamSocialService(ITeamSocialRepository _repository,IUnitOfWork _unitOfWork,IValidator<TeamSocial>_validator) : ITeamSocialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto createTeamDto)
        {
            var team = createTeamDto.Adapt<TeamSocial>();
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
                return BaseResult<object>.Fail("Team Social Not Found");
            }
            _repository.Delete(team);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync()
        {
            var teams = await _repository.GetAllAsync();
            var mappedResult = teams.Adapt<List<ResultTeamSocialDto>>();
            return BaseResult<List<ResultTeamSocialDto>>.Success(mappedResult);
        }



        public async Task<BaseResult<ResultTeamSocialDto>> GetByIdAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return BaseResult<ResultTeamSocialDto>.Fail("Team Social Not Found");
            }
            var resultTeam = team.Adapt<ResultTeamSocialDto>();
            return BaseResult<ResultTeamSocialDto>.Success(resultTeam);
        }

        public async Task<BaseResult<List<TeamSocialWithTeamNameSurnameDto>>> GetTeamSocialWithNameSurnameAsync()
        {
            var teamsSocialWithTeam = await _repository.GetTeamSocialsWithTeamAsync(); ;
            var mappedValues = teamsSocialWithTeam.Adapt<List<TeamSocialWithTeamNameSurnameDto>>();
            return BaseResult<List<TeamSocialWithTeamNameSurnameDto>>.Success(mappedValues);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto updateTeamDto)
        {
            var team = updateTeamDto.Adapt<TeamSocial>();
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
