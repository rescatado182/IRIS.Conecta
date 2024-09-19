using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.DTOs
{
    public class DepartmentsListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string RequestTypes { get; set; } = null!;
    }
}
