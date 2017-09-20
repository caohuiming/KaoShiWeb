using mode.Consulting;
using model.Account;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IHome
    {
        Myaccount Getaccunt(int id);
        int add(Consulting con);
       List< Myaccount> GetaccuntList(int id);
       int Deleteaccoun(int id);
        int UPdateaccoun(Myaccount mode);

        int UpdateColumn(Myaccount mode);

    }
}
