﻿using AutoMapper;
using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.ViewModels;
using kudapoyti.Domain.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Exceptions;
using System.Net;
using kudapoyti.Service.Dtos;

namespace kudapoyti.Service.Services.KudaPaytiService
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public PlaceService(IUnitOfWork unitOfWork,IMapper mapper,  AppDbContext appDbContext)
        {
            this._repository = unitOfWork;
            this._mapper = mapper;
            this._appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(PlaceCreateDto dto)
        {
            var entity = (Place)dto;
            entity.rank = 0;
            entity.rankedUsersCount= 0;
            entity.Ranked_point = 0;
            entity.CreatedAt = TimeHelper.GetCurrentServerTime();
            _appDbContext.Places.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _appDbContext.Places.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Places.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Car is not found.");
        }

        public Task<IEnumerable<Place>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlaceViewModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long id, PlaceCreateDto updateDto)
        {
            throw new NotImplementedException();
        }

    }
}
