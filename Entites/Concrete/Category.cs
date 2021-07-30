using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    //çıplak class kalmasın
    public class categoryId:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
