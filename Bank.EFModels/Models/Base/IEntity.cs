using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.EFModels.Models.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
