﻿using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class CurrencyService : ICurrencyService {
		#region Fields: Private

		private readonly IMapper _mapper;
		private readonly ICurrencyRepository _repo;

		#endregion

		#region Constructors: Public

		public CurrencyService(ICurrencyRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync() {
			var daos = await _repo.GetCurrenciesAsync();
			var dtos = _mapper.Map<IEnumerable<CurrencyDto>>(daos);
			return dtos;
		}
		public async Task<IEnumerable<CurrencyDto>> GetDeletedCurrenciesAsync() {
			var daos = await _repo.GetDeletedCurrenciesAsync();
			var dtos = _mapper.Map<IEnumerable<CurrencyDto>>(daos);
			return dtos;
		}
		public async Task<CurrencyDto> GetCurrencyAsync(Guid id) {
			var dao = await _repo.GetCurrencyAsync(id);
			var dto = _mapper.Map<CurrencyDto>(dao);
			return dto;
		}
		public async Task<CurrencyDto> AddCurrencyAsync(InsertCurrencyDto dto) {
			var dao = _mapper.Map<Currency>(dto);
			var resultDao = await _repo.AddCurrencyAsync(dao);
			var resultDto = _mapper.Map<CurrencyDto>(resultDao);
			return resultDto;
		}
		public async Task<CurrencyDto> UpdateCurrencyAsync(Guid id, InsertCurrencyDto entity) {
			var dao = _mapper.Map<Currency>(entity);
			dao.Id = id;
			var resultDao = await _repo.UpdateCurrencyAsync(dao);
			var dto = _mapper.Map<CurrencyDto>(resultDao);
			return dto;
		}
		public async Task<CurrencyDto> ActivateCurrencyAsync(Guid id, InsertCurrencyDto entity) {
			var dao = _mapper.Map<Currency>(entity);
			dao.Id = id;
			var resultDao = await _repo.ActivateCurrencyAsync(dao);
			var dto = _mapper.Map<CurrencyDto>(resultDao);
			return dto;
		}
		public async Task<CurrencyDto> DeleteCurrencyAsync(Guid id) {
			var dao = await _repo.DeleteCurrencyAsync(id);
			var dto = _mapper.Map<CurrencyDto>(dao);
			return dto;
		}

		#endregion
	}
}
