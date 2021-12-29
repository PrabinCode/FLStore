using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLStore.Shared;

namespace FLStore.Database.IServices
{
    public interface IProduct
    {
        List<ProductCommon> ProductList();
        ProductCommon GetProduct(ProductCommon common);
        CommonDbResponse ManageProduct(ProductCommon common);
        CommonDbResponse Block_UnblockProduct(ProductCommon common);

    }
}
