﻿using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ExchangeOffice.DataAccess.Repositories {
	public class ContactRepository : BaseRepository, IContactRepository {
		#region Fields: Private

		private readonly DataAccessContext _context;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public ContactRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<Contact>> GetContactsAsync() {
			return await Task.FromResult(_context.Contacts.Where(x => x.IsActive == true).AsNoTracking());
		}
		public async Task<Contact> GetContactAsync(Guid id) {
			var entity = await _context.Contacts.FindAsync(id);
			if(entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Contact with such id not found");
			}
			return entity;
		}
		public async Task<Contact> AddContactAsync(Contact entity) {
			SetDefaultValues(entity);
			await _context.Contacts.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Contact> UpdateContactAsync(Contact entity) {
			var oldEntity = await _context.Contacts.FindAsync(entity.Id);
			if (oldEntity == null || oldEntity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Contact with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Contact> DeactivateContactAsync(Guid id) {
			var entity = await _context.Contacts.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Contact with such id not found");
			}
			entity.IsActive = false;
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Contact> DeleteContactAsync(Guid id) {
			var entity = await _context.Contacts.FindAsync(id);
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Contact with such id not found");
			}
			_context.Contacts.Remove(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		#endregion
	}
}
