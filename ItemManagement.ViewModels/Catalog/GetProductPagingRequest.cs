using ItemManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ViewModels.Catalog
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}