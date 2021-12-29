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
    public class CommonService : ICommon
    {
        DAOCommon DAO;
        public CommonService()
        {
            DAO = new DAOCommon();
        }

        public Dictionary<string, string> Dropdown(string flag, string search1 = "")
        {
            string sql = "EXEC sproc_get_dropdown_list";
            sql += " @flag=" + DAO.FilterString(flag);
            sql += (string.IsNullOrEmpty(search1) ? "" : ", @search_field1=" + DAO.FilterString(search1));
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var dbres = DAO.ExecuteDataTable(sql);
            if (dbres != null)
            {
                foreach (DataRow dr in dbres.Rows)
                {
                    dict = dbres.AsEnumerable().ToDictionary<DataRow, string, string>(row => row["value"].ToString(), row => row["text"].ToString());
                }
            }

            else
                dict = null;
            return dict;
        }
    }
}
