using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Entites;

namespace Talabat.Core.Entites
{
    public class Basket : BaseEntite
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public int Price{ get; set; }

        public string PictureUrl{ get; set; }

        public string Brand{ get; set; }

        public string Type { get; set; }
    }
}
