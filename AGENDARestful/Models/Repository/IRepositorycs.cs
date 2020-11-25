using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AGENDARestful.Models.Repository
{
    public interface IRepository
    {
        SqlConnection GetConnection();
    }
}