using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Extensions
{
    public static class EnumExtension
    {
        public static int ToInt(this Enum @enum )
        {
            var type = @enum.GetType().GetEnumValues().Cast<int>().FirstOrDefault();

            return type;

        }
    }
}
