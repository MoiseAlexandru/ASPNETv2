﻿using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.NoteRepostitory
{
    public class NoteRepository : GenericRepository.GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(DatabaseContext context) : base(context) { }
        public List<Note> GetAllWithInclude()
        {
            return _table.Include(note => note.Profile).ToList();
        }

        public async Task<List<Note>> GetAllWithIncludeAsync()
        {
            return await _table.Include(note => note.Profile).ToListAsync();
        }
    }
}