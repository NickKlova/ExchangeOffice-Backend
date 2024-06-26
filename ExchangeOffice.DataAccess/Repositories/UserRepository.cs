﻿using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class UserRepository : BaseRepository, IUserRepository {
		private readonly DataAccessContext _context;
		public UserRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<User> GetUserAsync(string login) {
			var entity = await _context.Users
				.Include(x=>x.Contact)
				.Include(x=>x.Role)
				.Where(x=>x.Login == login && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "User with such login not found");
			}
			return entity;
		}
		public async Task<User> AddUserAsync(User entity) {
			SetDefaultValues(entity);
			await _context.Users.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<User> ChangeUserRoleAsync(string login, Guid roleId) {
			var entity = await _context.Users
				.Where(x => x.Login == login && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "User with such id not found");
			}
			var roleEntity = await _context.UserRoles.FindAsync(roleId);
			if (roleEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Role with such id not found");
			}
			entity.RoleId = roleId;
			entity.Role = roleEntity;
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<User> DeleteUserAsync(string login) {
			var entity = await _context.Users.Where(x=>x.Login == login).FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "User with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

	}
}
