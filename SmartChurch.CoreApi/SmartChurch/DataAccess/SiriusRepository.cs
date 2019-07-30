using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SmartChurch.DataModel.Models.Core;
using SmartChurch.Infrastructure.Helpers;

namespace SmartChurch.DataAccess
{
    public interface ISiriusRepository<TEntity, TEntityDto>
    {
        IEnumerable<TEntityDto> GetAll();
        //IEnumerable<TEntityDto> GetAllNonDeletable();
        IEnumerable<TEntityDto> Find(Expression<Func<TEntity, bool>> expression);
        TEntityDto GetById(int id);
        TEntityDto Create(TEntityDto dto);
        TEntityDto Update(int id, TEntityDto dto);
        //TEntityDto UpdateNonDeletable(int id, TEntityDto dto);
        int Delete(int id);
        int Delete(TEntityDto dto);
    }

    public class SiriusRepository<TEntity, TEntityDto> : ISiriusRepository<TEntity, TEntityDto> 
        where TEntityDto : class, ICommonDto 
        where TEntity : SiriusEntity
    {
        protected readonly Expression<Func<TEntity, bool>> IsNotDeletedExpression = s => s.IsDeletableEntity() && !s.IsDeleted();

        protected readonly SiriusDbContext Context;
        protected readonly IMapper Mapper;

        public SiriusRepository(SiriusDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual IEnumerable<TEntityDto> GetAll()
        {
            return Mapper.Map<List<TEntityDto>>(Context.Set<TEntity>().Where(IsNotDeletedExpression).ToList());
        }

        //public virtual IEnumerable<TEntityDto> GetAllNonDeletable()
        //{
        //    return Mapper.Map<List<TEntityDto>>(Context.Set<TEntity>().ToList());
        //}

        public virtual IEnumerable<TEntityDto> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Mapper.Map<List<TEntityDto>>(Context.Set<TEntity>().Where(IsNotDeletedExpression).Where(expression));
        }

        public virtual TEntityDto GetById(int id)
        {
            return Mapper.Map<TEntityDto>(Context.Set<TEntity>().Where(IsNotDeletedExpression).FirstOrDefault(s => s.Id == id));
        }

        public virtual TEntityDto Create(TEntityDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return Mapper.Map<TEntityDto>(entity);
        }

        public virtual TEntityDto Update(int id, TEntityDto dto)
        {
            var existingEntity = Context.Set<TEntity>().FirstOrDefault(s => !s.IsDeleted() && s.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Cannot find entity to update");
            }

            dto.Id = id;
            Context.Entry(existingEntity).CurrentValues.SetValues(dto);
            Context.SaveChanges();

            return Mapper.Map<TEntityDto>(existingEntity);
        }

        //public virtual TEntityDto UpdateNonDeletable(int id, TEntityDto dto)
        //{
        //    var existingEntity = Context.Set<TEntity>().FirstOrDefault(s => s.Id == id);
        //    if (existingEntity == null)
        //    {
        //        throw new KeyNotFoundException("Cannot find entity to update");
        //    }

        //    dto.Id = id;
        //    Context.Entry(existingEntity).CurrentValues.SetValues(dto);
        //    Context.SaveChanges();

        //    return Mapper.Map<TEntityDto>(existingEntity);
        //}

        public virtual int Delete(int id)
        {
            var entityDbSet = Context.Set<TEntity>();
            var itemToDelete = entityDbSet.FirstOrDefault(s => !s.IsDeleted() && s.Id == id);
            if (itemToDelete == null)
            {
                throw new KeyNotFoundException("Cannot find entity to delete");
            }

            entityDbSet.Remove(itemToDelete);
            return Context.SaveChanges();
        }

        public virtual int Delete(TEntityDto dto)
        {
            var entityDbSet = Context.Set<TEntity>();
            var itemToDelete = entityDbSet.FirstOrDefault(s => !s.IsDeleted() && s.Id == dto.Id);
            if (itemToDelete == null)
            {
                throw new KeyNotFoundException("Cannot find entity to delete");
            }

            entityDbSet.Remove(itemToDelete);
            return Context.SaveChanges();
        }
    }
}