﻿namespace SkillShare.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
    }
}
