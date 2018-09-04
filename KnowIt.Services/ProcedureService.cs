using KnowIt.Models.Procedure;
using KnowIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Contracts;

namespace KnowIt.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly Guid _userId;

        public ProcedureService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProcedure(ProcedureCreate model)
        {
            var entity =
                new Procedure()
                {
                    OwnerID = _userId,
                    ProcedureName = model.ProcedureName,
                    ProcedureNote = model.ProcedureNote,
                    ProcedureRoute = model.ProcedureRoute
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Procedures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProcedureListItem> GetProcedures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Procedures
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e => new ProcedureListItem
                                {
                                    ProcedureId = e.ProcedureID,
                                    ProcedureName = e.ProcedureName,
                                    ProcedureNote = e.ProcedureNote,
                                    ProcedureRoute = e.ProcedureRoute
                                }
                               );
                return query.ToArray();
            }
        }

        public ProcedureDetail GetProcedureById(int procedureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Procedures
                        .Single(e => e.ProcedureID == procedureId && e.OwnerID == _userId);
                return
                    new ProcedureDetail
                    {
                        ProcedureId = entity.ProcedureID,
                        ProcedureName = entity.ProcedureName,
                        ProcedureNote = entity.ProcedureNote,
                        ProcedureRoute = entity.ProcedureRoute
                    };
            }
        }

        public bool UpdateProcedure(ProcedureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Procedures
                        .Single(e => e.ProcedureID == model.ProcedureId && e.OwnerID == _userId);
                entity.ProcedureName = model.ProcedureName;
                entity.ProcedureNote = model.ProcedureNote;
                entity.ProcedureRoute = model.ProcedureRoute;
                    return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProcedure(int procedureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Procedures
                        .Single(e => e.ProcedureID == procedureId && e.OwnerID == _userId);
                ctx.Procedures.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public int GetProcedureIdFromStringName(string procedure)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var id =
                    ctx.Procedures.SingleOrDefault(p => p.ProcedureName == procedure);

                return id.ProcedureID;
            }
        }
    }
}
