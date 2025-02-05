using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneProje
{
     class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-D54BORL\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True;");
            baglan.Open();
            return baglan;
        }

    }
}
