﻿using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class FundService : IFundService {
		#region Fields: Private

		private readonly IFundRepository _repo;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public FundService(IFundRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<FundDto>> GetDeletedFundsAsync() {
			var daos = await _repo.GetDeletedFundsAsync();
			var dtos = _mapper.Map<IEnumerable<FundDto>>(daos);
			return dtos;
		}
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			var daos = await _repo.GetFundsAsync();
			var dtos = _mapper.Map<IEnumerable<FundDto>>(daos);
			return dtos;
		}
		public async Task<FundDto> GetFundAsync(Guid id) {
			var dao = await _repo.GetFundAsync(id);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<FundDto> GetFundByCurrencyIdAsync(Guid currencyId) {
			var dao = await _repo.GetFundByCurrencyIdAsync(currencyId);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<FundDto> AddFundAsync(InsertFundDto entity) {
			var dao = _mapper.Map<Fund>(entity);
			var resultDao = await _repo.AddFundAsync(dao);
			var dto = _mapper.Map<FundDto>(resultDao);
			return dto;
		}
		public async Task<FundDto> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount) {
			var dao = await _repo.UpdateFundByCurrencyIdAsync(currencyId, amount);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<FundDto> UpdateFundAsync(Guid id, InsertFundDto entity) {
			var dao = _mapper.Map<Fund>(entity);
			dao.Id = id;
			var resultDao = await _repo.UpdateFundAsync(dao);
			var dto = _mapper.Map<FundDto>(resultDao);
			return dto;
		}
		public async Task<FundDto> ActivateDeletedFundAsync(Guid id, InsertFundDto entity) {
			var dao = _mapper.Map<Fund>(entity);
			dao.Id = id;
			var resultDao = await _repo.ActivateDeletedFundAsync(dao);
			var dto = _mapper.Map<FundDto>(resultDao);
			return dto;
		}
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			var dao = await _repo.DeleteFundAsync(id);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}

		#endregion
	}
}
