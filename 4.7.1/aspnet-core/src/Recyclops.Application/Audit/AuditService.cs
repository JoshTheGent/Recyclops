using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityHistory;
using Microsoft.EntityFrameworkCore;
using Recyclops.Audit.Dto;
using Recyclops.Authorization.Users;

namespace Recyclops.Audit
{
    public class AuditService : IAuditService, ITransientDependency
    {
        #region Properties

        private readonly IRepository<EntityChangeSet, long> _entityChangeSetRepository;
        private readonly IRepository<User, long> _userRepository;

        #endregion

        #region Constructor

        public AuditService(IRepository<EntityChangeSet, long> entityChangeSetRepo, IRepository<User, long> userRepo)
        {
            _entityChangeSetRepository = entityChangeSetRepo;
            _userRepository = userRepo;
        }

        #endregion

        #region Methods

        public List<AuditServiceDto> GetAuditTypeReport(DateTime start, DateTime end)
        {
            end = end.AddHours(23).AddMinutes(59).AddSeconds(59);
            var returnData = new List<AuditServiceDto>();
            var entityChangeSetData = _entityChangeSetRepository.GetAll()
                .Where(x => x.CreationTime >= start && x.CreationTime <= end)
                .Include(x => x.EntityChanges)
                .ThenInclude(y => y.PropertyChanges)
                .ToList();

            foreach (var changeSet in entityChangeSetData)
            {
                if (changeSet.UserId == null) continue;
                var user = (_userRepository.Get((long)changeSet.UserId)).FullName;
                var date = changeSet.CreationTime;
                foreach (var change in changeSet.EntityChanges)
                {

                    var auditServiceDto = new AuditServiceDto(user, change.EntityTypeFullName, date, change.ChangeType);
                    var propertyChanges = change.PropertyChanges.Select(prop =>
                        new AuditDetailDto(prop.PropertyName, prop.OriginalValue, prop.NewValue)).ToList();
                    auditServiceDto.AuditDetails = propertyChanges;

                    returnData.Add(auditServiceDto);
                }
            }
            return returnData.OrderBy(x => x.Time).ThenBy(y => y.Type).ToList();
        }

        #endregion

    }
}
