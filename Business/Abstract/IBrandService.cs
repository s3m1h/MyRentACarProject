using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public IResult Add(Brand brand);
        public IResult Delete(Brand brand);
        public IResult Update(Brand brand);

        IDataResult<List<Brand>> GetAll();
    }
}
