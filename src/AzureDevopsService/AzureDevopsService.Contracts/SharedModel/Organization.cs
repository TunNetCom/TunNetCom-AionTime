using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsService.Contracts.SharedModel
{
    public class Organization
    {
        public string OrganizationName { get; set; }
        public List<string> ProjectsIds { get; set; }
    }
}