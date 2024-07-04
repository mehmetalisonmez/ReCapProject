using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Color = Entities.Concrete.Color;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentCarContext> ,IColorDal
    {
        
    }
}
