using AppJwtEmployee.DBL.AutoMapper.Abstract;
using AppJwtEmployee.DBL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Dtos
{
    public class AddDeparmentDto:IMapTo<Department>
    {
        public string Name { get; set; }
    }
}
