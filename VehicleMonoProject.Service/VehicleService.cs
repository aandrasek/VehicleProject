using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.Service.Models;

namespace VehicleMonoProject.Service
{
    public class VehicleService : IVehicleService
    {
        VehicleDB _context = new VehicleDB();
        public void CreateMake(IMake item)
        {
            _context.VehicleMake.Add(AutoMapper.Mapper.Map<Make>(item));
            _context.SaveChanges();
        }
        public IList<IMake> ReadMake(string sort)
        {
            var list = _context.VehicleMake.ToList();
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "Name":
                        list = list.OrderBy(c => c.Name).ToList();
                        break;
                    case "NameDesc":
                        list = list.OrderByDescending(c => c.Name).ToList();
                        break;
                    default:
                        list = list.OrderBy(c => c.Name).ToList();
                        break;
                }
            }
            return AutoMapper.Mapper.Map<IList<IMake>>(list);
        }
        public void UpdateMake(IMake item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteMake(IMake item)
        {
            _context.VehicleMake.Remove(_context.VehicleMake.Where(c => c.Id == item.Id).FirstOrDefault());
            _context.SaveChanges();
        }
        public IMake FindMakeWithID(int Id)
        {
            return _context.VehicleMake.Where(c => c.Id == Id).FirstOrDefault();
        }
        public PagedResult<IMake> ListMake(IList<IMake> list, int pageNumber, int pageSize)
        {
            var result = PagedResult<IMake>.GetPagedResultForQuery(list.AsQueryable(), pageNumber, pageSize);
            return AutoMapper.Mapper.Map<PagedResult<IMake>>(result);
        }


        public void CreateModel(IModel item)
        {
            _context.VehicleModel.Add(AutoMapper.Mapper.Map<Model>(item));
            _context.SaveChanges();
        }
        public IList<IModel> ReadModel(string sort)
        {
            var list = _context.VehicleModel.ToList();
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "Name":
                        list = list.OrderBy(c => c.Name).ToList();
                        break;
                    case "NameDesc":
                        list = list.OrderByDescending(c => c.Name).ToList();
                        break;
                    case "Make":
                        list = list.OrderBy(c => c.MakeId).ToList();
                        break;
                    default:
                        list = list.OrderBy(c => c.Name).ToList();
                        break;
                }
            }
            return AutoMapper.Mapper.Map<IList<IModel>>(list);
        }
        public void UpdateModel(IModel item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteModel(IModel item)
        {
            _context.VehicleModel.Remove(_context.VehicleModel.Where(c => c.Id == item.Id).FirstOrDefault());
            _context.SaveChanges();
        }
        public IModel FindModelWithID(int Id)
        {
            return _context.VehicleModel.Where(c => c.Id == Id).FirstOrDefault();
        }
        public PagedResult<IModel> ListModel(IList<IModel> list, int pageNumber, int pageSize)
        {
            var result = PagedResult<IModel>.GetPagedResultForQuery(list.AsQueryable(), pageNumber, pageSize);
            return AutoMapper.Mapper.Map<PagedResult<IModel>>(result);
        }

    }
}
