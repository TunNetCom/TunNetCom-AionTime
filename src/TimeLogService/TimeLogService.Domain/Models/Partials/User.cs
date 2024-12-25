using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogService.Domain.Models.Dbo;

public partial class User
{
    public User(
        string userId,
        string emailAddress,
        string publicAlias,
        int coreRevision,
        DateTime timeStamp,
        int revision)
    {
        UserId = userId;
        EmailAddress = emailAddress;
        PublicAlias = publicAlias;
        CoreRevision = coreRevision;
        TimeStamp = timeStamp;
        Revision = revision;
    }
}