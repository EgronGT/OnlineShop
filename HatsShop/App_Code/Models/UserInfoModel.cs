using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{
    
   public UserInformation GetUserInformation(string guId)
    {
        HatsShop_DBEntities db = new HatsShop_DBEntities();
        UserInformation info = (from x in db.UserInformations
                                   where x.DUID == guId
                                   select x).FirstOrDefault();
        return info;
    }
    public void InsertUserInformation(UserInformation info)
    {
        HatsShop_DBEntities db = new HatsShop_DBEntities();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }
     
}