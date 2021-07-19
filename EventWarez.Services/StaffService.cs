using EventWarez.Data;
using EventWarez.Models;
using EventWarez.Models.Staff;
using System.Collections.Generic;
using System.Linq;

namespace EventWarez.Services
{
    public class StaffService
    {
        public bool CreateStaff(StaffCreate model)
        {
            var entity =
              new Staff()
              {
                  FirstName = model.FirstName,
                  LastName = model.LastName,
                  AccessLevel = model.AccessLevel
              };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Staff.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StaffDetail> GetStaffDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Staff
                        .Select(
                            e => new StaffDetail
                            {
                                StaffId = e.StaffId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                AccessLevel = e.AccessLevel
                            }
                        );
                return query.ToArray();
            }
        }
        public StaffDetail GetStaffById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == id);

                return new StaffDetail
                {
                    StaffId = entity.StaffId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    AccessLevel = entity.AccessLevel,
                    WorkOrders = entity.WorkOrders
                    .Select(e => new WorkOrderDetail()
                    {
                        WorkOrderId = e.WorkOrderId,
                        StaffId = e.Staff.StaffId,
                        ShowId = e.ShowId,
                        Department = e.Department,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
                    }).ToList()
                };


            }
        }
        public bool UpdateStaff(StaffEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == model.StaffId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.AccessLevel = model.AccessLevel;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStaff(int staffId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == staffId);

                ctx.Staff.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
