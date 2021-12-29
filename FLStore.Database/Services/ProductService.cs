using FLStore.Database.IServices;
using FLStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Database.Services
{
    public class ProductService : IProduct
    {
        DAOCommon DAO;
        public ProductService()
        {
            DAO = new DAOCommon();
        }

        public List<ProductCommon> ProductList()
        {
            var sql = "EXEC sproc_product ";
            sql += "@flag = 'list' ";
            var dt = DAO.ExecuteDataTable(sql);
            var list = new List<ProductCommon>();
            if (null != dt)
            {
                int sn = 1;
                foreach (DataRow item in dt.Rows)
                {
                    var common = new ProductCommon
                    {
                        ProductId = item["ProductId"].ToString(),
                        ProductName = item["ProductName"].ToString(),
                        CategoryId = item["CategoryId"].ToString(),
                        ProductStatus = item["ProductStatus"].ToString(),
                        IsDeleted = item["IsDeleted"].ToString(),
                        //ProductDescription = item["ProductDescription"].ToString(),
                        ProductImage = item["ProductImage"].ToString(),
                        AvailableQuantity = item["AvailableQuantity"].ToString(),
                        AvailabelColor = item["AvailabelColor"].ToString(),
                        IsFeatured = item["IsFeatured"].ToString(),
                        ProductSize = item["ProductSize"].ToString(),
                        ProductWeight = item["ProductWeight"].ToString(),
                        ProductPrice = item["ProductPrice"].ToString(),
                        ProductShipTime = item["ProductShipTime"].ToString()

                    };
                    sn++;
                    list.Add(common);
                }
            }
            return list;
        }
        public ProductCommon GetProduct(ProductCommon common)
        {
            var sql = "EXEC sproc_product ";
            sql += "@flag = 'v' ";
            sql += ",@ProductId = " + DAO.FilterString(common.ProductId);
            var dt = DAO.ExecuteDataTable(sql);
            var item = new ProductCommon();
            if (null != dt)
            {
                int sn = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    item = new ProductCommon
                    {
                        ProductId = dr["ProductId"].ToString(),
                        ProductName = dr["ProductName"].ToString(),
                        CategoryId = dr["CategoryId"].ToString(),
                        ProductStatus = dr["ProductStatus"].ToString(),
                        IsDeleted = dr["IsDeleted"].ToString(),
                        //ProductDescription = dr["ProductDescription"].ToString(),
                        ProductImage = dr["ProductImage"].ToString(),
                        AvailableQuantity = dr["AvailableQuantity"].ToString(),
                        AvailabelColor = dr["AvailabelColor"].ToString(),
                        IsFeatured = dr["IsFeatured"].ToString(),
                        ProductSize = dr["ProductSize"].ToString(),
                        ProductWeight = dr["ProductWeight"].ToString(),
                        ProductPrice = dr["ProductPrice"].ToString(),
                        ProductShipTime = dr["ProductShipTime"].ToString()

                    };
                    return item;
                }
            }
            return item;
        }

        public CommonDbResponse ManageProduct(ProductCommon common)
        {
            var sql = "EXEC sproc_product ";
            sql += "@flag = '" + (string.IsNullOrEmpty(common.ProductId) ? "i" : "u") + "' ";
            sql += ", @ProductId        =" + DAO.FilterString(common.ProductId);
            sql += ", @ProductName      =" + DAO.FilterString(common.ProductName);
            sql += ", @CategoryId       =" + DAO.FilterString(common.CategoryId);
            sql += ", @ProductStatus    =" + DAO.FilterString(common.ProductStatus);
            sql += ", @IsDeleted        =" + DAO.FilterString(common.IsDeleted);
            sql += ", @ProductImage     =" + DAO.FilterString(common.ProductImage);
            sql += ", @AvailableQuantity=" + DAO.FilterString(common.AvailableQuantity);
            sql += ", @AvailabelColor   =" + DAO.FilterString(common.AvailabelColor);
            sql += ", @IsFeatured       =" + DAO.FilterString(common.IsFeatured);
            sql += ", @ProductSize      =" + DAO.FilterString(common.ProductSize);
            sql += ", @ProductWeight    =" + DAO.FilterString(common.ProductWeight);
            sql += ", @ProductPrice     =" + DAO.FilterString(common.ProductPrice);
            sql += ", @ProductShipTime  =" + DAO.FilterString(common.ProductShipTime);
            sql += ", @CreatedDate      =" + DAO.FilterString(common.CreatedDate);
            return DAO.ParseCommonDbResponse(sql);
        }

        public CommonDbResponse Block_UnblockProduct(ProductCommon common)
        {
            var sql = "EXEC sproc_product ";
            sql += " @flag='bu'";
            sql += ", @ProductStatus=" + DAO.FilterString(common.ProductStatus);
            sql += ", @ProductId=" + DAO.FilterString(common.ProductId);
            return DAO.ParseCommonDbResponse(sql);
        }

    }
}
